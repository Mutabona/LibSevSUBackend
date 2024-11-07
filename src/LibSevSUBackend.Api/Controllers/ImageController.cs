using System.Net;
using LibSevSUBackend.Api.Base;
using LibSevSUBackend.AppServices.Contexts.Files.Images.Services;
using LibSevSUBackend.Contracts.Files.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibSevSUBackend.Api.Controllers;

/// <summary>
/// Изображения.
/// </summary>
[ApiController]
[Route("[controller]")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class ImageController(IImageService imageService) : BaseController
{
    /// <summary>
    /// Выполняет поиск изображения по идентификатору.
    /// </summary>
    /// <param name="imageId">Идентификатор изображения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель изображения.</returns>
    [HttpGet("{imageId}")]
    [ProducesResponseType(typeof(ImageDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByImageIdAsync(Guid imageId, CancellationToken cancellationToken)
    {
        var image = await imageService.GetImageByIdAsync(imageId, cancellationToken);
        
        return File(image.Content, image.ContentType);
    }

    /// <summary>
    /// Добавляет изображение к книге.
    /// </summary>
    /// <param name="bookId">Книга, к которой добавляют изборажение</param>
    /// <param name="file">Изображение.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленного изображения.</returns>
    [Authorize(Roles = "Admin")]
    [HttpPost("/Book/{bookId}/Image")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> UploadImageToBookAsync(Guid bookId, IFormFile file, CancellationToken cancellationToken)
    {
        var fileId = await imageService.AddImageToBookAsync(bookId, file, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, fileId.ToString());
    }
    
    /// <summary>
    /// Добавляет изображение к новости.
    /// </summary>
    /// <param name="newsId">Идентификатор новости.</param>
    /// <param name="file">Изображение.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленного изображения.</returns>
    [Authorize(Roles = "Admin")]
    [HttpPost("/News/{newsId}/Image")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> UploadImageToNewsAsync(Guid newsId, IFormFile file, CancellationToken cancellationToken)
    {
        var fileId = await imageService.AddImageToNewsAsync(newsId, file, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, fileId.ToString());
    }
    
    /// <summary>
    /// Добавляет изображение к пользователю.
    /// </summary>
    /// <param name="file">Изображение.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленного изображения.</returns>
    [Authorize]
    [HttpPost("/User/Image")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> UploadImageToUserAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        var fileId = await imageService.AddImageToUserAsync(userId, file, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, fileId.ToString());
    }

    /// <summary>
    /// Удаляет изображение пользователя.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("/User/Image")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> DeleteUserImageAsync(CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        await imageService.DeleteUserImageAsync(userId, cancellationToken);
        
        return NoContent();
    }
    
    /// <summary>
    /// Удаляет изображение книги.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpDelete("/Book/{bookId:guid}/Image")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> DeleteBookImageAsync(Guid bookId, CancellationToken cancellationToken)
    {
        await imageService.DeleteBookImageAsync(bookId, cancellationToken);
        
        return NoContent();
    }
    
    /// <summary>
    /// Удаляет изображение новости.
    /// </summary>
    /// <param name="newsId">Идентификатор новости.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpDelete("/News/{newsId}/Image")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> DeleteNewsImageAsync(Guid newsId, CancellationToken cancellationToken)
    {
        await imageService.DeleteNewsImageAsync(newsId, cancellationToken);
        
        return NoContent();
    }
}