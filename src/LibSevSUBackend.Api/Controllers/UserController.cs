using System.Net;
using LibSevSUBackend.Api.Base;
using LibSevSUBackend.AppServices.Contexts.Users.Services;
using LibSevSUBackend.Contracts.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibSevSUBackend.Api.Controllers;

/// <summary>
/// Пользователи.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class UserController(IUserService userService) : BaseController
{
    /// <summary>
    /// Добавляет книгу пользователю в избранное.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [HttpPost("favorite")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> AddFavoriteBook(Guid bookId, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        await userService.AddFavoriteBookAsync(userId, bookId, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Возвращает список избранных книг.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция книг.</returns>
    [HttpGet("favorite")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(IReadOnlyCollection<BookDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFavoriteBooks(CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        var result = await userService.GetFavoriteBooksAsync(userId, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаляет книгу из избранного.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [HttpDelete("favorite/{bookId}")]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> RemoveFavoriteBook(Guid bookId, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        await userService.RemoveFavoriteBookAsync(userId, bookId, cancellationToken);
        return NoContent();
    }
}