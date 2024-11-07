using LibSevSUBackend.Domain.Files.Images.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibSevSUBackend.DataAccess.Configurations;

/// <summary>
/// Конфигурация изображения.
/// </summary>
public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder
            .ToTable("Image");
        
        builder
            .HasKey(x => x.Id);
        
    }
}