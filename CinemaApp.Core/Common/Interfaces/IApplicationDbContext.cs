using Microsoft.EntityFrameworkCore;
using СinemaApp.Domain.Entities;
using СinemaApp.MVVM.Model.Entities;

namespace CinemaApp.Core.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Actor> Actors { get; }

        DbSet<Film> Films { get; }

        DbSet<Genre> Genres { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
