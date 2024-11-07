using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibSevSUBackend.DataAccess.Configurations;

/// <summary>
/// Конфигурация новостей.
/// </summary>
public class NewsConfiguration : IEntityTypeConfiguration<Domain.News.Entity.News>
{
    public void Configure(EntityTypeBuilder<Domain.News.Entity.News> builder)
    {
        builder.ToTable("News");
        
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Image)
            .WithOne();
    }
}