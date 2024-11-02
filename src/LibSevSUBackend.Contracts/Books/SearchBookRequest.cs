using BulletinBoard.Contracts.Base;

namespace LibSevSUBackend.Contracts.Books;

/// <summary>
/// Модель запроса на поиск книги.
/// </summary>
public class SearchBookRequest : BasePaginationRequest
{
    /// <summary>
    /// Строка поиска.
    /// </summary>
    public string? SearchString { get; set; }
    
    /// <summary>
    /// Минимальная дата выпуска.
    /// </summary>
    public DateOnly? StartDate { get; set; }
    
    /// <summary>
    /// Максимальная дата выпуска.
    /// </summary>
    public DateOnly? EndDate { get; set; }
}