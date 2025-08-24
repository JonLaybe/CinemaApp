using CinemaApp.Core.Services.Films;
using CinemaApp.Core.Services.Genres;
using CinemaApp.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApp.Core.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddTransient<IFilmService, FilmService>()
                .AddTransient<IGenreService, GenreService>();

            return services;
        }
    }
}
