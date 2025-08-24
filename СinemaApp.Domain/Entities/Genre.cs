using СinemaApp.MVVM.Model.Entities;

namespace СinemaApp.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public IList<Film>? Films { get; set; }
    }
}
