using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LibSevSUBackend.AppServices.Contexts.Books.Builders;
using LibSevSUBackend.AppServices.Contexts.Books.Repositories;
using LibSevSUBackend.AppServices.Contexts.Books.Services;
using LibSevSUBackend.AppServices.Contexts.Files.Images.Repositories;
using LibSevSUBackend.AppServices.Contexts.Files.Images.Services;
using LibSevSUBackend.AppServices.Contexts.News.Repositories;
using LibSevSUBackend.AppServices.Contexts.News.Services;
using LibSevSUBackend.AppServices.Contexts.Users.Repositories;
using LibSevSUBackend.AppServices.Contexts.Users.Services;
using LibSevSUBackend.AppServices.Services;
using LibSevSUBackend.AppServices.Validators.Users;
using LibSevSUBackend.ComponentRegistrar.MapProfiles;
using LibSevSUBackend.Contracts.News;
using LibSevSUBackend.DataAccess;
using LibSevSUBackend.DataAccess.Books.Repository;
using LibSevSUBackend.DataAccess.Files.Images.Repository;
using LibSevSUBackend.DataAccess.News.Repository;
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
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IImageService, ImageService>();
        services.AddTransient<INewsService, NewsService>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IBookSpecificationBuilder, BookSpecificationBuilder>();
        
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
            cfg.AddProfile<BookProfile>();
            cfg.AddProfile<ImageProfile>();
            cfg.AddProfile<NewsProfile>();
        });
        
        configuration.AssertConfigurationIsValid();
        return configuration;
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LoginUserRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<RegisterUserRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<AddBookRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<AddNewsRequestValidator>();
        services.AddFluentValidationAutoValidation();

        return services;
    }
}