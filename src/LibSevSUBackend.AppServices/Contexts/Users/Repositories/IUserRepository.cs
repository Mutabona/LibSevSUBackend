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
    /// Получение пользователя по почте.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Данные пользователя <see cref="UserDto"/></returns>
    Task<UserDto> GetByLoginAsync(string login, CancellationToken cancellationToken);
}