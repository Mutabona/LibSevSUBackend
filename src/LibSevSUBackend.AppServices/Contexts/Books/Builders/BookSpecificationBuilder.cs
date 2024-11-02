using BulletinBoard.AppServices.Specifications;
using LibSevSUBackend.AppServices.Contexts.Books.Specifications;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Domain.Books.Entity;

namespace LibSevSUBackend.AppServices.Contexts.Books.Builders;

///<inheritdoc cref="IBookSpecificationBuilder"/>
public class BookSpecificationBuilder : IBookSpecificationBuilder
{
    /// <inheritdoc />
    public ISpecification<Book> Build(SearchBookRequest request)
    {
        var specification = Specification<Book>.True;
        
        if (!string.IsNullOrWhiteSpace(request.SearchString))
        {
            specification = specification.And(new SearchStringSpecification(request.SearchString));
        }

        if (request.StartDate.HasValue)
        {
            specification = specification.And(new MinDateSpecification(request.StartDate.Value));
        }
        
        if (request.EndDate.HasValue)
        {
            specification = specification.And(new MaxDateSpecification(request.EndDate.Value));
        }
        
        return specification;
    }
}