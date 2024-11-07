namespace LibSevSUBackend.Contracts.News;

/// <summary>
/// Новость.
/// </summary>
public class NewsDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Названия новости.
    /// </summary>
    public string Label { get; set; }
    
    /// <summary>
    /// Текст новости.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Фото новости.
    /// </summary>
    public Guid? ImageId { get; set; }
}