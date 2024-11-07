using LibSevSUBackend.Contracts.Files.Images;
using Microsoft.AspNetCore.Http;

namespace LibSevSUBackend.AppServices.Contexts.Files.Images.Services;

/// <summary>
/// Сервис для работы с изображениями.
/// </summary>
public interface IImageService
{
    /// <summary>
    /// Удаляет изображение.
    /// </summary>
    /// <param name="imageId">Идентификатор изображения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteImageAsync(Guid imageId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает изображение по идентификатору.
    /// </summary>
    /// <param name="imageId">Идентификатор изображения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Изображение.</returns>
    Task<ImageDto> GetImageByIdAsync(Guid imageId, CancellationToken cancellationToken);

    /// <summary>
    /// Добавляет изображение к пользователю.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="file">Изображение</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленного изображения.</returns>
    Task<Guid> AddImageToUserAsync(Guid userId, IFormFile file, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет изображение к книге.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="file">Изображение</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор добавленного изображения.</returns>
    Task<Guid> AddImageToBookAsync(Guid bookId, IFormFile file, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет фото пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteUserImageAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет фото книги.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteBookImageAsync(Guid bookId, CancellationToken cancellationToken);
}