using System.Linq.Expressions;
using BulletinBoard.AppServices.Specifications;
using LibSevSUBackend.Domain.Books.Entity;

namespace LibSevSUBackend.AppServices.Contexts.Books.Specifications;

/// <summary>
/// Спецификация поиска по минимальной дате издания.
/// </summary>
/// <param name="date">Дата.</param>
public class MinDateSpecification(DateOnly date) : Specification<Book>
{
    /// <inheritdoc />
    public override Expression<Func<Book, bool>> PredicateExpression =>
        book => book.PublishDate >= date;
}