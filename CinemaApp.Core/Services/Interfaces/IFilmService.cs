using CinemaApp.Core.Models.Film;
using СinemaApp.Domain.Entities;

namespace CinemaApp.Core.Services.Interfaces
{
    public interface IFilmService
    {
        /// <summary>
        /// Asynchronously selected an entity by id.
        /// </summary>
        /// <param name="id">Identifier entity of type <see cref="Film" />.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contain entity <see cref="FilmDto" /> .
        /// </returns>
        Task<FilmDto?> GetEntityByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs an asynchronous search for elements of type <see cref="Film" /> based on the specified search parameters.
        /// </summary>
        /// <param name="surchStr">String request.</param>
        /// <param name="selectedIdsGenres">Array of genre ids of type <see cref="int" />.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result list contains entities <see cref="FilmDto" />.
        /// </returns>
        Task<IList<FilmDto>> SurchFilmAsync(string surchStr, int[] selectedIdsGenres, CancellationToken cancellationToken = default);
    }
}
