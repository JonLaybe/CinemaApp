using CinemaApp.Core.Common.Interfaces;
using CinemaApp.Core.Models.Actors;
using CinemaApp.Core.Models.Film;
using CinemaApp.Core.Models.Genres;
using CinemaApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using СinemaApp.Domain.Entities;
using СinemaApp.MVVM.Model.Entities;

namespace CinemaApp.Core.Services.Films
{
    public class FilmService : IFilmService
    {
        private IApplicationDbContext _dbContext;

        public FilmService(IApplicationDbContext context)
        {
            this._dbContext = context;
        }

        public async Task<FilmDto?> GetEntityByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await this._dbContext.Films.Where(x => id == x.Id).Select(x => new FilmDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                LinkPreview = x.LinkPreview,
                Actors = x.Actors.Select(at => new ActorDto() {
                    Name = at.Name
                }).ToList(),
                Genres = x.Genres.Select(gr => new GenreDto()
                {
                    Name = gr.Name,
                }).ToList(),
            }).FirstOrDefaultAsync(cancellationToken);

        public async Task<IList<FilmDto>> SurchFilmAsync(string surchStr, int[] selectedIdsGenres, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(surchStr))
                return await this._dbContext.Films.Where(fl => fl.Genres.Any(gn => selectedIdsGenres.Contains(gn.Id)))
                    .Select(x => new FilmDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        LinkPreview = x.LinkPreview,
                    }).ToListAsync(cancellationToken);

            return await this._dbContext.Films.Where(fl => fl.Name.Contains(surchStr) ||
            fl.Actors.Any(ac => ac.Name.Contains(surchStr)) ||
            fl.Genres.Any(gn => selectedIdsGenres.Contains(gn.Id)))
                .Select(x => new FilmDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                LinkPreview = x.LinkPreview,
            }).ToListAsync(cancellationToken);
        }
    }
}
