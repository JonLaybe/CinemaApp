using CinemaApp.Core.Services.Genres;
using CinemaApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Test
{
    public class GenreServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllEntitesAsyncTest()
        {
            var countGenre = 5;
            var options = this.GetDbOption();
            using (var dbContext = new ApplicationDbContext(options))
            {
                var genreService = new GenreService(dbContext);

                var result = await genreService.GetAllEntitesAsync();

                Assert.IsTrue(result.Count == countGenre);
            }
        }

        private DbContextOptions<ApplicationDbContext> GetDbOption()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UsedByMigratorOnly1.db3");
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite($"Filename={dbPath}");

            return options.Options;
        }
    }
}
