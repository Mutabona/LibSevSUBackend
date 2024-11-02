using FluentValidation;
using LibSevSUBackend.Contracts.Books;

namespace LibSevSUBackend.AppServices.Validators.Users;

/// <summary>
/// Валидатор для <see cref="AddBookRequest"/>.
/// </summary>
public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
{
    /// <summary>
    /// Создаёт экземпляр <see cref="AddBookRequestValidator"/>.
    /// </summary>
    public AddBookRequestValidator()
    {
        RuleFor(request => request.Author).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.PublishDate).NotEmpty();
    }
}