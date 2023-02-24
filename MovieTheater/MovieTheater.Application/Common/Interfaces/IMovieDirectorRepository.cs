using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IMovieDirectorRepository
{
    Task<IEnumerable<MovieDirector>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<MovieDirector?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(MovieDirector director, CancellationToken cancellationToken = default);
    void Delete(MovieDirector director);
}