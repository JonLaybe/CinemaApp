using CinemaApp.Core.Models.Genres;

namespace CinemaApp.MVVM.Models.Entity
{
    public class ClientGenre : GenreDto
    {
        public bool IsSelected { get; set; } = false;
    }
}
