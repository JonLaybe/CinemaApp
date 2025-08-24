using CinemaApp.Core.Services.Interfaces;
using CinemaApp.MVVM.Models.Entity;
using System.Collections.ObjectModel;
using CinemaApp.MVVM.Utilites;
using CinemaApp;
using CinemaApp.Core.Models.Film;

namespace СinemaApp.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<FilmDto> ListFilm { get; set; }
        public ObservableCollection<ClientGenre> ListGenres { get; set; }

        private IFilmService _filmService;
        private IGenreService _genreService;
        private string _textSurchFilm = "";
        private string _surchActor = "";
        private bool _isLogingSurch = false;

        public MainViewModel(IFilmService filmService,
            IGenreService genreService)
        {
            this._filmService = filmService;
            this._genreService = genreService;

            this.ListFilm = new ObservableCollection<FilmDto>();
            this.ListGenres = new ObservableCollection<ClientGenre>();

            this.GetAllGenreAsync();
        }

        public string TextSurch
        {
            get { return _textSurchFilm; }
            set
            {
                _textSurchFilm = value;
                this.OnPropertyChanged(nameof(TextSurch));
            }
        }

        public string SurchActor
        {
            get { return _surchActor; }
            set
            {
                this._surchActor = value;
                this.OnPropertyChanged(nameof(this.SurchActor));
            }
        }

        public RelayCommand SelectedGenreClick
        {
            get
            {
                return new RelayCommand(async (object obj) =>
                {
                    await Shell.Current.GoToAsync($"{nameof(DetailePage)}?IdFilm={obj}");
                });
            }
        }

        public RelayCommand SurchButton
        {
            get
            {
                return new RelayCommand((object obj) =>
                {
                    this._isLogingSurch = true;
                    this.InvokeSurchAsync(this.TextSurch);
                }, new Func<object, bool>((object ob) =>
                {
                    return !this._isLogingSurch;
                }));
            }
        }

        private async void InvokeSurchAsync(string textSurch, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(textSurch) && !this.ListGenres.Any(x => x.IsSelected))
            {
                this._isLogingSurch = false;
                return;
            }

            var listGenreSelected = this.ListGenres.Where(x => x.IsSelected).Select(x => x.Id).ToArray();

            var result = await this._filmService.SurchFilmAsync(textSurch, listGenreSelected, cancellationToken);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                this.ListFilm.Clear();
                foreach (var film in result)
                {
                    this.ListFilm.Add(film);
                }
                this._isLogingSurch = false;
            });
        }

        private async void GetAllGenreAsync(CancellationToken cancellationToken = default)
        {
            var result = await this._genreService.GetAllEntitesAsync(cancellationToken);

            var list = result.Select(x => new ClientGenre()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                this.ListGenres = new ObservableCollection<ClientGenre>(list);
            });
        }
    }
}
