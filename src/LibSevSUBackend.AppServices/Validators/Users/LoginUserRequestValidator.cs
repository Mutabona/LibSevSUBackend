using FluentValidation;
using LibSevSUBackend.Contracts.Users;

namespace LibSevSUBackend.AppServices.Validators.Users;

/// <summary>
/// Валидатор запроса на вход пользователя.
/// </summary>
public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
{
    /// <summary>
    /// Создаёт экземпляр <see cref="LoginUserRequestValidator"/>.
    /// </summary>
    public LoginUserRequestValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Пароль не может быть пустым.")
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Login)
            .NotEmpty()
            .WithMessage("Логин не может быть пустым.")
            .MinimumLength(2)
            .MaximumLength(50);
    }
}