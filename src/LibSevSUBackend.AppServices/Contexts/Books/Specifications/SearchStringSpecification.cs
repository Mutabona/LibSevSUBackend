using System.Linq.Expressions;
using BulletinBoard.AppServices.Specifications;
using LibSevSUBackend.Domain.Books.Entity;

namespace LibSevSUBackend.AppServices.Contexts.Books.Specifications;

/// <summary>
/// Спецификация поиска книг по поисковой строке.
/// </summary>
public class SearchStringSpecification : Specification<Book>
{
    private readonly string _searchString;

    /// <summary>
    /// Создаёт спецификацию поиска книг по поисковой строке <see cref="SearchStringSpecification"/>.
    /// </summary>
    /// <param name="searchString">Поисковая строка.</param>
    public SearchStringSpecification(string searchString)
    {
        _searchString = searchString;
    }

    /// <inheritdoc />
    public override Expression<Func<Book, bool>> PredicateExpression =>
        book =>
            book.Name.ToLower().Contains(_searchString.ToLower()) ||
            book.Description.ToLower().Contains(_searchString.ToLower()) ||
            book.Author.ToLower().Contains(_searchString.ToLower());
}