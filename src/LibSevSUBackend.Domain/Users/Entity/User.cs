using LibSevSUBackend.Domain.Base;
using LibSevSUBackend.Domain.Books.Entity;

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
}