using LibSevSUBackend.Domain.Base;
using LibSevSUBackend.Domain.Files.Images.Entity;
using LibSevSUBackend.Domain.Files.Images.Entity.Base;

namespace LibSevSUBackend.Domain.Books.Entity;

/// <summary>
/// Книга.
/// </summary>
public class Book : BaseEntity
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Автор.
    /// </summary>
    public string Author { get; set; }
    
    /// <summary>
    /// Дата издания.
    /// </summary>
    public DateOnly PublishDate { get; set; }
    
    /// <summary>
    /// Идентификатор фото.
    /// </summary>
    public Guid? PhotoId { get; set; }
    
    /// <summary>
    /// Фото.
    /// </summary>
    public virtual Image Photo { get; set; }
}