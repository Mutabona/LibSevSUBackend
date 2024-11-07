using LibSevSUBackend.Domain.Users.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibSevSUBackend.DataAccess.Configurations;

/// <summary>
/// Конифгурация пользователя.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Login)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasMany(x => x.FavoriteBooks)
            .WithMany();
        
        builder
            .HasOne(x => x.Photo)
            .WithOne();
    }
}