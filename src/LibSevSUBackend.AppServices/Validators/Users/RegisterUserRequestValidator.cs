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
            .WithMessage("Минимальная длина пароля 2 символа.")
            .MaximumLength(50)
            .WithMessage("Максимальная длина пароля 50 символов.");

        RuleFor(x => x.Login)
            .NotEmpty()
            .WithMessage("Логин не может быть пустым.")
            .Matches("[a-zA-Z0-9_-]+")
            .WithMessage("В логине можно использовать только латиницу.")
            .MinimumLength(2)
            .WithMessage("Минимальная длина логина 2 символа.")
            .MaximumLength(50)
            .WithMessage("Максимальная длина логина 50 символов.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Имя не может быть пустым.")
            .MinimumLength(1)
            .MaximumLength(50);
    }
}