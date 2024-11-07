using LibSevSUBackend.Domain.Base;
using LibSevSUBackend.Domain.Files.Images.Entity.Base;

namespace LibSevSUBackend.Domain.News.Entity;

/// <summary>
/// Новость.
/// </summary>
public class News : BaseEntity
{
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
    
    /// <summary>
    /// Фото.
    /// </summary>
    public Image Image { get; set; }
}