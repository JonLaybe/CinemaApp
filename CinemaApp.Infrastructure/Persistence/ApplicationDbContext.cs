using CinemaApp.Core.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using СinemaApp.Domain.Entities;
using СinemaApp.MVVM.Model.Entities;

namespace CinemaApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public static bool Initialized { get; protected set; }

        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<Film> Films => Set<Film>();
        public DbSet<Genre> Genres => Set<Genre>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            SQLitePCL.Batteries_V2.Init();

            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
