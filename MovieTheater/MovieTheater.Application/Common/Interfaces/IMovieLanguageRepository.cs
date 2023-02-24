using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IMovieLanguageRepository
{
    Task<IEnumerable<MovieLanguage>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<MovieLanguage>> GetAllByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default);

    Task<IEnumerable<MovieLanguage>>
        GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    Task<MovieLanguage?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(MovieLanguage language, CancellationToken cancellationToken = default);
    void Delete(MovieLanguage language);
}