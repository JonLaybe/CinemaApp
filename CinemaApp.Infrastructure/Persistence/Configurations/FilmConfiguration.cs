using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СinemaApp.Domain.Entities;

namespace CinemaApp.Infrastructure.Persistence.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            _ = builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            _ = builder.Property(x => x.Description).HasMaxLength(256);

            _ = builder.Property(x => x.LinkPreview).HasMaxLength(256);
        }
    }
}
