namespace LibSevSUBackend.Contracts.Users;

/// <summary>
/// Запрос на регистрацию пользователя.
/// </summary>
public class RegisterUserRequest
{
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }
}