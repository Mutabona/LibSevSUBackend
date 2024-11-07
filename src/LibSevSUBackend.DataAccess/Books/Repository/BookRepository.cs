using AutoMapper;
using AutoMapper.QueryableExtensions;
using BulletinBoard.AppServices.Specifications;
using LibSevSUBackend.AppServices.Contexts.Books.Repositories;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Domain.Books.Entity;
using LibSevSUBackend.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibSevSUBackend.DataAccess.Books.Repository;

///<inheritdoc cref="IBookRepository"/>
public class BookRepository(IRepository<Book> repository, IMapper mapper) : IBookRepository
{
    ///<inheritdoc/>
    public async Task<Guid> AddBookAsync(BookDto book, CancellationToken cancellationToken)
    {
        var bookEntity = mapper.Map<Book>(book);
        return await repository.AddAsync(bookEntity, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task DeleteBookAsync(Guid bookId, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(bookId, cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<BookDto> GetBookByIdAsync(Guid bookId, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(bookId, cancellationToken);
        return mapper.Map<BookDto>(book);
    }

    ///<inheritdoc/>
    public async Task<ICollection<BookDto>> GetBySpecificationWithPaginationAsync(ISpecification<Book> specification, int take, int? skip,
        CancellationToken cancellationToken)
    {
        var query = repository
            .GetAll()
            .OrderBy(b => b.Id)
            .Where(specification.PredicateExpression);
        
        if (skip.HasValue) query = query.Skip(skip.Value);
        
        return await query
            .Take(take)
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
    
    ///<inheritdoc/>
    public async Task AddImageAsync(Guid bookId, Guid imageId, CancellationToken cancellationToken)
    {
        var book = await repository
            .GetByPredicate(u => u.Id == bookId)
            .FirstOrDefaultAsync(cancellationToken);
        book.PhotoId = imageId;
        await repository.UpdateAsync(book, cancellationToken);
    }
}