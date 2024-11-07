using LibSevSUBackend.Domain.Base;
using LibSevSUBackend.Domain.Books.Entity;
using LibSevSUBackend.Domain.Files.Images.Entity;
using LibSevSUBackend.Domain.Files.Images.Entity.Base;

namespace LibSevSUBackend.Domain.Users.Entity;

/// <summary>
/// Сущность пользователя.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Роль в системе.
    /// </summary>
    public string Role { get; set; }
    
    /// <summary>
    /// Избранные книги.
    /// </summary>
    public virtual ICollection<Book> FavoriteBooks { get; set; } = new List<Book>();
    
    /// <summary>
    /// Идентификатор фото.
    /// </summary>
    public Guid? PhotoId { get; set; }
    
    /// <summary>
    /// Фото.
    /// </summary>
    public virtual Image Photo { get; set; }
}