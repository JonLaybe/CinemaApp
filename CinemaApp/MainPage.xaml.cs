using CinemaApp.Core.Common.Interfaces;
using CinemaApp.Infrastructure.Persistence;
using СinemaApp.Domain.Entities;
using СinemaApp.MVVM.Model.Entities;
using СinemaApp.MVVM.ViewModels;

namespace CinemaApp
{
    public partial class MainPage : ContentPage
    {
        private IApplicationDbContext _context;

        public MainPage(IApplicationDbContext context, MainViewModel vm)
        {
            this._context = context;
            InitializeComponent();
            this.BindingContext = vm;

            //this.InitDb();
        }

        private async void InitDb()
        {

            var actors = new List<Actor>() { new Actor() { Name = "Райан Рейнольдс" }, new Actor() { Name = "Морена Баккарин" },
                new Actor() { Name = "Брэд Питт" }, new Actor() { Name = "Карен Фукухара" } };
            var genres = new List<Genre>() { new Genre() { Name = "Комедия" }, new Genre() { Name = "Боевик" },
                new Genre() { Name = "Фантастика" }, new Genre() { Name = "Приключения" }, new Genre { Name = "Триллер" } };

            this._context.Films.Add(new Film()
            {
                Name = "Дэдпул 2",
                Actors = new List<Actor>() { actors[0], actors[1] },
                Description = "Единственный и неповторимый болтливый наемник — вернулся! Ещё более масштабный, ещё более разрушительный и даже ещё более голозадый, чем прежде! Когда в его жизнь врывается суперсолдат с убийственной миссией, Дэдпул вынужден задуматься о дружбе, семье и о том, что на самом деле значит быть героем, попутно надирая 50 оттенков задниц. Потому что иногда чтобы делать хорошие вещи, нужно использовать грязные приёмчики.",
                Genres = new List<Genre>() { genres[0], genres[1], genres[2], genres[3], genres[4] },
            });

            this._context.Films.Add(new Film()
            {
                Name = "Быстрее пули",
                Description = "Пятеро наёмных убийц оказываются в одном сверхскоростном экспрессе. Они узнают, что их миссии связаны, и пытаются выяснить, кто и зачем собрал их вместе.",
                Actors = new List<Actor>() { actors[0], actors[2], actors[3] },
                Genres = new List<Genre>() { genres[0], genres[1], genres[4] },
            });

            await this._context.SaveChangesAsync();
        }
    }
}
