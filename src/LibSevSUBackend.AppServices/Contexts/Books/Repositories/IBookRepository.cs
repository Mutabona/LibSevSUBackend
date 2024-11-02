using BulletinBoard.AppServices.Specifications;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Domain.Books.Entity;

namespace LibSevSUBackend.AppServices.Contexts.Books.Repositories;

/// <summary>
/// Репозиторий для работы с книгами.
/// </summary>
public interface IBookRepository
{
    /// <summary>
    /// Добавляет книгу.
    /// </summary>
    /// <param name="book">Модель книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленной книги.</returns>
    Task<Guid> AddBookAsync(BookDto book, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет книгу по идентификатору.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteBookAsync(Guid bookId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает книгу по идентификатору.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель книги.</returns>
    Task<BookDto> GetBookByIdAsync(Guid bookId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Выполняет получение книг по спецификации с пагинацией.
    /// </summary>
    /// <param name="specification">Спецификация.</param>
    /// <param name="take">Количество элементов для выборки.</param>
    /// <param name="skip">Количество элементов для пропуска.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей книг.</returns>
    Task<ICollection<BookDto>> GetBySpecificationWithPaginationAsync(
        ISpecification<Book> specification, 
        int take, 
        int? skip,
        CancellationToken cancellationToken);
}