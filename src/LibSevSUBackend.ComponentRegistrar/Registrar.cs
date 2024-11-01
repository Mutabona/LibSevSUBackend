using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LibSevSUBackend.AppServices.Contexts.Users.Repositories;
using LibSevSUBackend.AppServices.Contexts.Users.Services;
using LibSevSUBackend.AppServices.Services;
using LibSevSUBackend.AppServices.Validators.Users;
using LibSevSUBackend.ComponentRegistrar.MapProfiles;
using LibSevSUBackend.DataAccess;
using LibSevSUBackend.DataAccess.Users.Repository;
using LibSevSUBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibSevSUBackend.ComponentRegistrar;

/// <summary>
/// Класс для регистрации компонентов в IoC-контейнере.
/// </summary>
public static class Registrar
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IJwtService, JwtService> ();
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        
        services.AddScoped<DbContext>(s => s.GetRequiredService<ApplicationDbContext>());

        services.AddFluentValidation();
        
        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserProfile>();
        });
        
        configuration.AssertConfigurationIsValid();
        return configuration;
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LoginUserRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<RegisterUserRequestValidator>();
        services.AddFluentValidationAutoValidation();

        return services;
    }
}