using FluentValidation;
using LibSevSUBackend.Contracts.News;

namespace LibSevSUBackend.AppServices.Validators.Users;

/// <summary>
/// Валидатор для <see cref="AddNewsRequest"/>
/// </summary>
public class AddNewsRequestValidator : AbstractValidator<AddNewsRequest>
{
    public AddNewsRequestValidator()
    {
        RuleFor(x => x.Label).NotEmpty().WithMessage("Название новости не может быть пустой.");
        RuleFor(x => x.Text).NotEmpty().WithMessage("Текст новости не может быть пустым.");
    }
}