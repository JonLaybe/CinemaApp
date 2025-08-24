using CinemaApp.Core.Models.Genres;

namespace CinemaApp.Core.Services.Interfaces
{
    public interface IGenreService
    {
        /// <summary>
        /// Get all entities asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result list contains entities <see cref="GenreDto" />.
        /// </returns>
        Task<IList<GenreDto>> GetAllEntitesAsync(CancellationToken cancellationToken = default);
    }
}
