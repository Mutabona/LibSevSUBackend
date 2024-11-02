using BulletinBoard.AppServices.Specifications;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Domain.Books.Entity;

namespace LibSevSUBackend.AppServices.Contexts.Books.Builders;

/// <summary>
/// Строит спецификации для книг.
/// </summary>
public interface IBookSpecificationBuilder
{
    /// <summary>
    /// Строит спецификацию по запросу.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <returns>Спецификация.</returns>
    ISpecification<Book> Build(SearchBookRequest request);
}