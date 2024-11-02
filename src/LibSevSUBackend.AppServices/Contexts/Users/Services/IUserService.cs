using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Contracts.Users;

namespace LibSevSUBackend.AppServices.Contexts.Users.Services;

/// <summary>
/// Сервис для работы с пользователями.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Регистрирует пользователя.
    /// </summary>
    /// <param name="request">Запрос на регистрацию.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор зарегистрированного пользователя.</returns>
    Task<Guid> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Запрос на авторизацию пользователя.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>JWT</returns>
    Task<string> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет пользователя по идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Проверяет уникальность почты.
    /// </summary>
    /// <param name="email">Почта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если почта уникальная, иначе false.</returns>
    Task<bool> IsUniqueLoginAsync(string email, CancellationToken cancellationToken);
    
    /// <summary>
    /// Проверяет является ли указанный пользователь администратором.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если является, false, если нет.</returns>
    Task<bool> IsUserAdminAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет книгу пользователю в избранное.
    /// </summary>
    /// <param name="userId">Идентификтор пользователя.</param>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task AddFavoriteBookAsync(Guid userId, Guid bookId, CancellationToken cancellationToken);

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