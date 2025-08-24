using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СinemaApp.Domain.Entities;

namespace CinemaApp.Infrastructure.Persistence.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            _ = builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}
