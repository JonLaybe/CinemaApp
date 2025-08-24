using CinemaApp.Core.Common.Interfaces;
using CinemaApp.Core.Models.Genres;
using CinemaApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Core.Services.Genres
{
    public class GenreService : IGenreService
    {
        private IApplicationDbContext _dbContext;

        public GenreService(IApplicationDbContext context)
        {
            this._dbContext = context;
        }

        public async Task<IList<GenreDto>> GetAllEntitesAsync(CancellationToken cancellationToken = default) =>
            await this._dbContext.Genres.Select(x => new GenreDto()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync(cancellationToken);
    }
}
