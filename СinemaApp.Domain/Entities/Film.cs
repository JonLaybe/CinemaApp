using СinemaApp.MVVM.Model.Entities;

namespace СinemaApp.Domain.Entities
{
    public class Film : BaseEntity
    {
        public string Name { get; set; }

        public string? LinkPreview { get; set; }

        public string? Description { get; set; }

        public IList<Actor>? Actors { get; set; }

        public IList<Genre>? Genres { get; set; }
    }
}
