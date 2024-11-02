using LibSevSUBackend.Domain.Base;

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
}