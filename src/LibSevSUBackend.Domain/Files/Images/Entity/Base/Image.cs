using LibSevSUBackend.Domain.Base;

namespace LibSevSUBackend.Domain.Files.Images.Entity.Base;

/// <summary>
/// Сущность фото.
/// </summary>
public class Image : BaseEntity
{
    /// <summary>
    /// Контент фото.
    /// </summary>
    public byte[] Content { get; set; }

    /// <summary>
    /// Тип контента фото.
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// Размер фото.
    /// </summary>
    public int Length { get; set; }
}