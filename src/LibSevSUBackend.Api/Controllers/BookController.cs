using System.Net;
using LibSevSUBackend.Api.Base;
using LibSevSUBackend.AppServices.Contexts.Books.Services;
using LibSevSUBackend.Contracts.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibSevSUBackend.Api.Controllers;

/// <summary>
/// Книги.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class BookController(IBookService service) : BaseController
{
    /// <summary>
    /// Добавляет книгу по модели запроса.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленной нкиги.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddBookAsync(AddBookRequest request, CancellationToken cancellationToken)
    {
        var bookId = await service.AddBookAsync(request, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, bookId);
    }
    
    /// <summary>
    /// Удаляет книгу по идентификатору.
    /// </summary>
    /// <param name="bookId">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [HttpDelete("{bookId}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteBookAsync(Guid bookId, CancellationToken cancellationToken)
    {
        await service.DeleteBookAsync(bookId, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Возвращает книгу по идентификатору.
    /// </summary>
    /// <param name="bookId">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель книги.</returns>
    [HttpGet("{bookId}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBookByIdAsync(Guid bookId, CancellationToken cancellationToken)
    {
        var book = await service.GetBookByIdAsync(bookId, cancellationToken);
        return Ok(book);
    }

    /// <summary>
    /// Выполняет поиск книг по модели запроса.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей объявлений.</returns>
    [HttpPost("search")]
    [ProducesResponseType(typeof(ICollection<BookDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SearchBooksAsync(SearchBookRequest request, CancellationToken cancellationToken)
    {
        var books = await service.SearchBooksWithPaginationAsync(request, cancellationToken);
        return Ok(books);
    }
}