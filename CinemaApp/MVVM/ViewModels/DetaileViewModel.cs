using CinemaApp.Core.Models.Actors;
using CinemaApp.Core.Models.Film;
using CinemaApp.Core.Services.Interfaces;

namespace СinemaApp.MVVM.ViewModels
{
    [QueryProperty("IdFilm", "IdFilm")]
    public class DetaileViewModel : BaseViewModel
    {
        private IFilmService _filmService;
        private FilmDto _selectedFilm;
        private int _selectedIdFilm = 0;

        public DetaileViewModel(IFilmService filmService)
        {
            this._filmService = filmService;
        }

        public int IdFilm
        {
            set
            {
                this._selectedIdFilm = value;
                this.InitMoveAsync();
            }
        }

        public FilmDto SelectedFilm
        {
            get { return _selectedFilm; }
            set
            {
                _selectedFilm = value;
                this.OnPropertyChanged(nameof(this.SelectedFilm));
            }
        }

        private async void InitMoveAsync(CancellationToken cancellationToken = default)
        {
            var result = await this._filmService.GetEntityByIdAsync(this._selectedIdFilm, cancellationToken);

            if (result == null)
                return;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                this.SelectedFilm = result;
            });
        }
    }
}
