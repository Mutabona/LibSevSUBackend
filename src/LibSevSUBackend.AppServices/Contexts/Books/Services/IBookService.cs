using LibSevSUBackend.Contracts.Books;

namespace LibSevSUBackend.AppServices.Contexts.Books.Services;

/// <summary>
/// Сервис для работы с книгами.
/// </summary>
public interface IBookService
{
    /// <summary>
    /// Добавляет книгу.
    /// </summary>
    /// <param name="book">Модель книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленной книги.</returns>
    Task<Guid> AddBookAsync(AddBookRequest book, CancellationToken cancellationToken);
    
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
    /// Выполняет поиск книг по запросу с пагинацией.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция книг.</returns>
    Task<ICollection<BookDto>> SearchBooksWithPaginationAsync(SearchBookRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Проверяет, существует ли книга по идентификатору.
    /// </summary>
    /// <param name="bookId">Идентификатор книги</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>True, если существует, false, если нет.</returns>
    Task<bool> IsBookExistsAsync(Guid bookId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет изображение к книге.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="imageId">Идентификатор изображения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task AddImageAsync(Guid bookId, Guid imageId, CancellationToken cancellationToken);
}