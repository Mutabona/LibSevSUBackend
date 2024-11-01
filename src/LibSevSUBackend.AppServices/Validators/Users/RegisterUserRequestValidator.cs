using System.Text.RegularExpressions;
using FluentValidation;
using LibSevSUBackend.Contracts.Users;

namespace LibSevSUBackend.AppServices.Validators.Users;

/// <summary>
/// Валидатор запроса на создание пользователя.
/// </summary>
public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    /// <summary>
    /// Создаёт экземпляр <see cref="RegisterUserRequestValidator"/>.
    /// </summary>
    public RegisterUserRequestValidator()
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

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Имя не может быть пустым.")
            .MinimumLength(1)
            .MaximumLength(50);
    }
}