using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibSevSUBackend.AppServices.Contexts.Users.Repositories;
using LibSevSUBackend.AppServices.Exceptions;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Contracts.Users;
using LibSevSUBackend.Domain.Books.Entity;
using LibSevSUBackend.Domain.Users.Entity;
using LibSevSUBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibSevSUBackend.DataAccess.Users.Repository;

///<inheritdoc cref="IUserRepository"/>
public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Создаёт экземпляр <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="mapper">Маппер.</param>
    public UserRepository(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    ///<inheritdoc/>
    public async Task<Guid> AddAsync(UserDto user, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<User>(user);
        return await _repository.AddAsync(userEntity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<UserDto> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken)
    { 
        var user = await _repository
            .GetAll()
            .Where(s => s.Login == request.Login && s.Password == request.Password)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null) throw new EntityNotFoundException();
        return user;
    }

    ///<inheritdoc/>
    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(userId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<UserDto> GetByLoginAsync(string login, CancellationToken cancellationToken)
    {
        var user = await _repository
            .GetAll()
            .Where(s => s.Login == login)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (user == null) throw new EntityNotFoundException();
        return user;
    }

    ///<inheritdoc/>
    public async Task<UserDto> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(userId, cancellationToken);
        return _mapper.Map<UserDto>(user);
    }

    ///<inheritdoc/>
    public async Task AddFavoriteBookAsync(Guid userId, BookDto book, CancellationToken cancellationToken)
    {
        var user = await _repository
            .GetByPredicate(u => u.Id == userId)
            .Include(b => b.FavoriteBooks)
            .FirstOrDefaultAsync(cancellationToken);
        var bookEntity = _mapper.Map<Book>(book);
        user.FavoriteBooks.Add(bookEntity);
        await _repository.UpdateAsync(user, cancellationToken);
    }
    
    ///<inheritdoc/>
    public async Task RemoveFavoriteBookAsync(Guid userId, Guid bookId, CancellationToken cancellationToken)
    {
        var user = await _repository
            .GetByPredicate(u => u.Id == userId)
            .Include(b => b.FavoriteBooks)
            .FirstOrDefaultAsync(cancellationToken);
        var book = user.FavoriteBooks.FirstOrDefault(b => b.Id == bookId);
        if (book == null) throw new ConflictException();
        user.FavoriteBooks.Remove(book);
        await _repository.UpdateAsync(user, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<IReadOnlyCollection<BookDto>> GetFavoriteBooksAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var user = await _repository
            .GetAll()
            .Where(u => u.Id == userId)
            .Include(b => b.FavoriteBooks)
            .FirstOrDefaultAsync(cancellationToken);
        var books = _mapper.Map<IReadOnlyCollection<BookDto>>(user.FavoriteBooks);
        return books;
    }

    ///<inheritdoc/>
    public async Task AddImageAsync(Guid userId, Guid imageId, CancellationToken cancellationToken)
    {
        var user = await _repository
            .GetByPredicate(u => u.Id == userId)
            .Include(b => b.FavoriteBooks)
            .FirstOrDefaultAsync(cancellationToken);
        user.PhotoId = imageId;
        await _repository.UpdateAsync(user, cancellationToken);
    }
}