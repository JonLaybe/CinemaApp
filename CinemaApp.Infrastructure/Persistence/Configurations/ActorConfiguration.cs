using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СinemaApp.MVVM.Model.Entities;

namespace CinemaApp.Infrastructure.Persistence.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            _ = builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}
