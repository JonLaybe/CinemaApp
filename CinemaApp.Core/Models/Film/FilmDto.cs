using CinemaApp.Core.Models.Actors;
using CinemaApp.Core.Models.Genres;

namespace CinemaApp.Core.Models.Film
{
    public class FilmDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? LinkPreview { get; set; }

        public string? Description { get; set; }

        public IList<ActorDto>? Actors { get; set; }

        public IList<GenreDto>? Genres { get; set; }
    }
}
