using AutoMapper;
using LibSevSUBackend.Contracts.News;
using LibSevSUBackend.Domain.News.Entity;

namespace LibSevSUBackend.ComponentRegistrar.MapProfiles;

/// <summary>
/// Профиль новости.
/// </summary>
public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<AddNewsRequest, NewsDto>(MemberList.None);
        
        CreateMap<NewsDto, News>(MemberList.None).ReverseMap();
    }
}