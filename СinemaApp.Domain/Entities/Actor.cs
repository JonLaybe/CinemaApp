using СinemaApp.Domain.Entities;

namespace СinemaApp.MVVM.Model.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }

        public IList<Film>? Films { get; set; }
    }
}
