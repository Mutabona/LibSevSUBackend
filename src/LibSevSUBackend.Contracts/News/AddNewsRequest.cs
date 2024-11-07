namespace LibSevSUBackend.Contracts.News;

/// <summary>
/// Запрос на добавление новости.
/// </summary>
public class AddNewsRequest
{
    /// <summary>
    /// Названия новости.
    /// </summary>
    public string Label { get; set; }
    
    /// <summary>
    /// Текст новости.
    /// </summary>
    public string Text { get; set; }
}