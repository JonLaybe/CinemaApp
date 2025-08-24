using CinemaApp.Core.Services.Films;
using CinemaApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Test
{
    public class FilmServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetEntityByIdAsyncTest()
        {
            var id = 1;
            var options = this.GetDbOption();
            using (var dbContext = new ApplicationDbContext(options))
            {
                var filmService = new FilmService(dbContext);

                var result = await filmService.GetEntityByIdAsync(id);

                Assert.IsTrue(result.Id == id);
            }
        }

        [Test]
        public async Task SurchFilmAsyncTest()
        {
            var idGenre = 1;
            var options = this.GetDbOption();
            using (var dbContext = new ApplicationDbContext(options))
            {
                var filmService = new FilmService(dbContext);

                var result = await filmService.SurchFilmAsync("Test", []);
                var result2 = await filmService.SurchFilmAsync("Test", [idGenre]);

                Assert.IsFalse(result.Any());
                Assert.IsTrue(result2.Any());
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