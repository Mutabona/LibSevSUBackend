using LibSevSUBackend.Domain.Books.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibSevSUBackend.DataAccess.Configurations;

/// <summary>
/// Конфигурация книги.
/// </summary>
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .ToTable("Books");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Name)
            .IsRequired();
        
        builder
            .Property(x => x.Author)
            .IsRequired();
        
        builder
            .Property(x => x.PublishDate)
            .IsRequired();
    }
}