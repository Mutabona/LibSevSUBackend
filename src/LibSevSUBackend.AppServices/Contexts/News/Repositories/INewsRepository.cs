using LibSevSUBackend.Contracts.News;

namespace LibSevSUBackend.AppServices.Contexts.News.Repositories;

/// <summary>
/// Репозиторий для работы с новостями.
/// </summary>
public interface INewsRepository
{
    /// <summary>
    /// Добавляет новость.
    /// </summary>
    /// <param name="news">Новость.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификтор созданной новости.</returns>
    Task<Guid> AddNewsAsync(NewsDto news, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет новость.
    /// </summary>
    /// <param name="id">Идентификатор новости.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteNewsAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавление новости.
    /// </summary>
    /// <param name="take">Сколько получить.</param>
    /// <param name="skip">Сколько пропустить.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция моделей новостей.</returns>
    Task<ICollection<NewsDto>> GetNewsAsync(int take, int? skip, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает новость по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Модель новости.</returns>
    Task<NewsDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет изображение к новости.
    /// </summary>
    /// <param name="newsId">Идентификатор новости.</param>
    /// <param name="imageId">Идентификатор изображения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task AddImageAsync(Guid newsId, Guid imageId, CancellationToken cancellationToken);
}