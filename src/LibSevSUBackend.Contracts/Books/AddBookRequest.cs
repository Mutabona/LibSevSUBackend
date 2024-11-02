namespace LibSevSUBackend.Contracts.Books;

/// <summary>
/// Модель запроса на добавление книги.
/// </summary>
public class AddBookRequest
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
    public DateOnly? PublishDate { get; set; }
}