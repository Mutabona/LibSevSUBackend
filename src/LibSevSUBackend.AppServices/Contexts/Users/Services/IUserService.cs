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
}