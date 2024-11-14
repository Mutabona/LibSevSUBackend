using System.Net;
using LibSevSUBackend.Api.Base;
using LibSevSUBackend.AppServices.Contexts.News.Services;
using LibSevSUBackend.Contracts.Books;
using LibSevSUBackend.Contracts.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibSevSUBackend.Api.Controllers;

/// <summary>
/// Новости.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class NewsController(INewsService service) : BaseController
{
    /// <summary>
    /// Добавляет новости по модели запроса.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленной новости.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddNewsAsync(AddNewsRequest request, CancellationToken cancellationToken)
    {
        var newsId = await service.AddNewsAsync(request, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, newsId);
    }
    
    /// <summary>
    /// Удаляет новость по идентификатору.
    /// </summary>
    /// <param name="newsId">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [HttpDelete("{newsId}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteBookAsync(Guid newsId, CancellationToken cancellationToken)
    {
        await service.DeleteNewsAsync(newsId, cancellationToken);
        return NoContent();
    }
    
    /// <summary>
    /// Выполняет получение новостей с пагинацией.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей новостей.</returns>
    [HttpPost("search")]
    [ProducesResponseType(typeof(ICollection<NewsDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SearchBooksAsync(int take, int? skip, CancellationToken cancellationToken)
    {
        var books = await service.GetNewsAsync(take, skip, cancellationToken);
        return Ok(books);
    }

    /// <summary>
    /// Получает новость по идентификатору.
    /// </summary>
    /// <param name="newsId">Идентификатор новости.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель новости.</returns>
    [HttpGet("{newsId}")]
    [ProducesResponseType(typeof(NewsDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetNewsByIdAsync(Guid newsId, CancellationToken cancellationToken)
    {
        var news = await service.GetByIdAsync(newsId, cancellationToken);
        return Ok(news);
    }
}