namespace LibSevSUBackend.Contracts.Books;

/// <summary>
/// Книга.
/// </summary>
public class BookDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }
    
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