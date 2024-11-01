using AutoMapper;
using LibSevSUBackend.Contracts.Users;
using LibSevSUBackend.Domain.Users.Entity;

namespace LibSevSUBackend.ComponentRegistrar.MapProfiles;

/// <summary>
/// Профиль пользователя.
/// </summary>
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserRequest, UserDto>(MemberList.None);
        
        CreateMap<User, UserDto>(MemberList.None).ReverseMap();
    }
}