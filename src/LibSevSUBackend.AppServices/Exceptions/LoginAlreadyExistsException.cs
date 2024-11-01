namespace LibSevSUBackend.AppServices.Exceptions;

/// <summary>
/// Ошибка "Этот логин уже зарегистрирован".
/// </summary>
public class LoginAlreadyExistsException : Exception
{
    public LoginAlreadyExistsException() : base("Этот логин уже зарегистрирован.")
    {
        
    }
}