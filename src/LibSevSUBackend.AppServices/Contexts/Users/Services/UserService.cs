using AutoMapper;
using LibSevSUBackend.AppServices.Contexts.Books.Services;
using LibSevSUBackend.AppServices.Contexts.Users.Repositories;
using LibSevSUBackend.AppServices.Exceptions;
using LibSevSUBackend.AppServices.Helpers;
using LibSevSUBackend.AppServices.Services;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Contracts.Users;
using LibSevSUBackend.Domain.Files.Images.Entity;

namespace LibSevSUBackend.AppServices.Contexts.Users.Services;

///<inheritdoc cref="IUserService"/>
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;
    private readonly IBookService _bookService;

    /// <summary>
    /// Создаёт экземпляр <see cref="UserService"/>.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="jwtService">Сервис для создания jwt.</param>
    /// <param name="mapper">Маппер.</param>
    /// <param name="bookService">Сервис для работы с книгами.</param>
    public UserService(IUserRepository repository, IJwtService jwtService, IMapper mapper, IBookService bookService)
    {
        _repository = repository;
        _jwtService = jwtService;
        _mapper = mapper;
        _bookService = bookService;
    }

    ///<inheritdoc/>
    public async Task<Guid> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        if (await IsUniqueLoginAsync(request.Login, cancellationToken))
        {
            request.Password = CryptoHelper.GetBase64Hash(request.Password);
            var user = _mapper.Map<UserDto>(request);
            user.Role = "User";
            user.Id = Guid.NewGuid();
            var userId =  await _repository.AddAsync(user, cancellationToken);
            
            return userId;
        }
        else
        {
            throw new LoginAlreadyExistsException();
        }
    }

    ///<inheritdoc/>
    public async Task<string> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken)
    {
        request.Password = CryptoHelper.GetBase64Hash(request.Password);
        UserDto user;
        try
        {
            user = await _repository.LoginAsync(request, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            throw new InvalidLoginDataException();
        }
        
        return _jwtService.GetToken(request, user.Id, user.Role);
    }

    ///<inheritdoc/>
    public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(userId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<bool> IsUniqueLoginAsync(string login, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _repository.GetByLoginAsync(login, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return true;
        }
        return false;
    }

    ///<inheritdoc/>
    public async Task<bool> IsUserAdminAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(userId, cancellationToken);
        if (user.Role == "Admin") return true;
        return false;
    }

    ///<inheritdoc/>
    public async Task AddFavoriteBookAsync(Guid userId, Guid bookId, CancellationToken cancellationToken)
    {
        if (! (await _bookService.IsBookExistsAsync(bookId, cancellationToken))) throw new EntityNotFoundException();
        
        var book = await _bookService.GetBookByIdAsync(bookId, cancellationToken);
        await _repository.AddFavoriteBookAsync(userId, book, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<IReadOnlyCollection<BookDto>> GetFavoriteBooksAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var books = await _repository.GetFavoriteBooksAsync(userId, cancellationToken);
        return books;
    }
    
    ///<inheritdoc/>
    public async Task RemoveFavoriteBookAsync(Guid userId, Guid bookId, CancellationToken cancellationToken)
    {
        if (! (await _bookService.IsBookExistsAsync(bookId, cancellationToken))) throw new EntityNotFoundException();
        
        await _repository.RemoveFavoriteBookAsync(userId, bookId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task AddImageAsync(Guid userId, Guid imageId, CancellationToken cancellationToken)
    {
        await _repository.AddImageAsync(userId, imageId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(userId, cancellationToken);
    }
}