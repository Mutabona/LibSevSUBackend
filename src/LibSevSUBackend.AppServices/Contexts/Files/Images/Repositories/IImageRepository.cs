using LibSevSUBackend.Contracts.Files.Images;

namespace LibSevSUBackend.AppServices.Contexts.Files.Images.Repositories;

/// <summary>
/// Репозиторий дя работы с изображениями.
/// </summary>
public interface IImageRepository
{
    /// <summary>
    /// Сохраняет изображение.
    /// </summary>
    /// <param name="image">Изображение.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор изображения.</returns>
    Task<Guid> AddAsync(ImageDto image, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет изображение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает изображение по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Изображение.</returns>
    Task<ImageDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}