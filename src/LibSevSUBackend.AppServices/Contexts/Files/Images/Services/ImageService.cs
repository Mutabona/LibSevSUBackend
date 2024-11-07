using AutoMapper;
using LibSevSUBackend.AppServices.Contexts.Books.Services;
using LibSevSUBackend.AppServices.Contexts.Files.Images.Repositories;
using LibSevSUBackend.AppServices.Contexts.News.Services;
using LibSevSUBackend.AppServices.Contexts.Users.Services;
using LibSevSUBackend.Contracts.Files.Images;
using Microsoft.AspNetCore.Http;

namespace LibSevSUBackend.AppServices.Contexts.Files.Images.Services;

///<inheritdoc cref="IImageService"/>
public class ImageService : IImageService
{
    private readonly IImageRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IBookService _bookService;
    private readonly INewsService _newsService;

    /// <summary>
    /// Создаёт экземпляр <see cref="ImageService"/>.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="mapper">Маппер.</param>
    /// <param name="userService">Сервис для работы с пользователями.</param>
    /// <param name="bookService">Сервис для работы с книгами.</param>
    /// <param name="newsService">Сервис для работы с новостями.</param>
    public ImageService(IImageRepository repository, IMapper mapper, IUserService userService, IBookService bookService, INewsService newsService)
    {
        _repository = repository;
        _mapper = mapper;
        _userService = userService;
        _bookService = bookService;
        _newsService = newsService;
    }

    /// <inheritdoc />
    public async Task<Guid> AddImageToUserAsync(Guid userId, IFormFile file, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(userId, cancellationToken);
        if (user.PhotoId.HasValue)
        {
            await _repository.DeleteAsync(user.PhotoId.Value, cancellationToken);
        }
        
        var entity = _mapper.Map<ImageDto>(file);
        entity.Id = Guid.NewGuid();
        var imageId = await _repository.AddAsync(entity, cancellationToken);
        
        await _userService.AddImageAsync(userId, imageId, cancellationToken);
        
        return entity.Id;
    }

    /// <inheritdoc />
    public async Task<Guid> AddImageToBookAsync(Guid bookId, IFormFile file, CancellationToken cancellationToken)
    {
        var book = await _bookService.GetBookByIdAsync(bookId, cancellationToken); //Проверка на существование книги
        if (book.PhotoId.HasValue)
        {
            await _repository.DeleteAsync(book.PhotoId.Value, cancellationToken);
        }
        
        var entity = _mapper.Map<ImageDto>(file);
        entity.Id = Guid.NewGuid();
        var imageId = await _repository.AddAsync(entity, cancellationToken);
        
        await _bookService.AddImageAsync(bookId, imageId, cancellationToken);
        return entity.Id;
    }

    /// <inheritdoc />
    public async Task<Guid> AddImageToNewsAsync(Guid newsId, IFormFile file, CancellationToken cancellationToken)
    {
        var news = await _newsService.GetByIdAsync(newsId, cancellationToken); //Проверка на существование книги
        if (news.ImageId.HasValue)
        {
            await _repository.DeleteAsync(news.ImageId.Value, cancellationToken);
        }
        
        var entity = _mapper.Map<ImageDto>(file);
        entity.Id = Guid.NewGuid();
        var imageId = await _repository.AddAsync(entity, cancellationToken);
        
        await _newsService.AddImageAsync(newsId, imageId, cancellationToken);
        return entity.Id;
    }

    /// <inheritdoc />
    public async Task DeleteUserImageAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(userId, cancellationToken);
        if (user.PhotoId.HasValue)
        {
            await _repository.DeleteAsync(user.PhotoId.Value, cancellationToken);
        }
    }

    /// <inheritdoc />
    public async Task DeleteBookImageAsync(Guid bookId, CancellationToken cancellationToken)
    {
        var book = await _bookService.GetBookByIdAsync(bookId, cancellationToken);
        if (book.PhotoId.HasValue)
        {
            await _repository.DeleteAsync(book.PhotoId.Value, cancellationToken);
        }
    }

    /// <inheritdoc />
    public async Task DeleteNewsImageAsync(Guid newsId, CancellationToken cancellationToken)
    {
        var news = await _newsService.GetByIdAsync(newsId, cancellationToken); //Проверка на существование книги
        if (news.ImageId.HasValue)
        {
            await _repository.DeleteAsync(news.ImageId.Value, cancellationToken);
        }
    }

    /// <inheritdoc />
    public async Task DeleteImageAsync(Guid imageId, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(imageId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ImageDto> GetImageByIdAsync(Guid imageId, CancellationToken cancellationToken)
    {
        return await  _repository.GetByIdAsync(imageId, cancellationToken);
    }
}