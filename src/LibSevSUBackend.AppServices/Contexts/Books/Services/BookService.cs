using AutoMapper;
using LibSevSUBackend.AppServices.Contexts.Books.Builders;
using LibSevSUBackend.AppServices.Contexts.Books.Repositories;
using LibSevSUBackend.AppServices.Contexts.Users.Services;
using LibSevSUBackend.AppServices.Exceptions;
using LibSevSUBackend.Contracts.Books;

namespace LibSevSUBackend.AppServices.Contexts.Books.Services;

///<inheritdoc cref="IBookService"/>
public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;
    private readonly IBookSpecificationBuilder _specificationBuilder;

    /// <summary>
    /// Создаёт экземпляр <see cref="BookService"/>.
    /// </summary>
    /// <param name="repository">Репозиторий для работы с объявлениями.</param>
    /// <param name="mapper">Маппер.</param>
    /// <param name="specificationBuilder">Строитель спецификаций.</param>
    public BookService(IBookRepository repository, IMapper mapper, IBookSpecificationBuilder specificationBuilder)
    {
        _repository = repository;
        _mapper = mapper;
        _specificationBuilder = specificationBuilder;
    }

    /// <inheritdoc />
    public async Task<Guid> AddBookAsync(AddBookRequest book, CancellationToken cancellationToken)
    {
        var bookEntity = _mapper.Map<BookDto>(book);
        bookEntity.Id = Guid.NewGuid();
        return await _repository.AddBookAsync(bookEntity, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteBookAsync(Guid bookId, CancellationToken cancellationToken)
    {
        await _repository.DeleteBookAsync(bookId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<BookDto> GetBookByIdAsync(Guid bookId, CancellationToken cancellationToken)
    {
        return await _repository.GetBookByIdAsync(bookId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ICollection<BookDto>> SearchBooksWithPaginationAsync(SearchBookRequest request, CancellationToken cancellationToken)
    {
        var specification = _specificationBuilder.Build(request);
        
        return await _repository.GetBySpecificationWithPaginationAsync(specification, request.Take, request.Skip, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> IsBookExistsAsync(Guid bookId, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.GetBookByIdAsync(bookId, cancellationToken);
        }
        catch (EntityNotFoundException)
        {
            return false;
        }
        return true;
    }
    
    ///<inheritdoc/>
    public async Task AddImageAsync(Guid userId, Guid imageId, CancellationToken cancellationToken)
    {
        await _repository.AddImageAsync(userId, imageId, cancellationToken);
    }
}