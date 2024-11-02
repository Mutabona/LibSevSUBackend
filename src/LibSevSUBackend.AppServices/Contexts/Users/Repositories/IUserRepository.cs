using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Contracts.Users;

namespace LibSevSUBackend.AppServices.Contexts.Users.Repositories;

/// <summary>
/// Репозитория для работы с пользователями.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Добавляет пользователя.
    /// </summary>
    /// <param name="user">Новый пользователь.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор нового пользователя.</returns>
    Task<Guid> AddAsync(UserDto user, CancellationToken cancellationToken);
    
    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="request">Запрос на авторизацию <see cref="LoginUserRequest"/>.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task<UserDto> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет пользователя по айди.
    /// </summary>
    /// <param name="userId">Айди.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение пользователя по логину.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Данные пользователя <see cref="UserDto"/></returns>
    Task<UserDto> GetByLoginAsync(string login, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение пользователя по идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель пользователя.</returns>
    Task<UserDto> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет поользователя книгу в избранные.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="book">Модель книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task AddFavoriteBookAsync(Guid userId, BookDto book, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает избранные книги пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекцию моделей книг.</returns>
    Task<IReadOnlyCollection<BookDto>> GetFavoriteBooksAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет книгу из избранного.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task RemoveFavoriteBookAsync(Guid userId, Guid bookId, CancellationToken cancellationToken);
}