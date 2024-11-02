using AutoMapper;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Domain.Books.Entity;

namespace LibSevSUBackend.ComponentRegistrar.MapProfiles;

/// <summary>
/// Профиль книги.
/// </summary>
public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<AddBookRequest, BookDto>(MemberList.None);

        CreateMap<BookDto, Book>(MemberList.None).ReverseMap();
    }
}