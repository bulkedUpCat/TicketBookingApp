using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Genre>> GetAllByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    Task<Genre?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Genre genre, CancellationToken cancellationToken = default);
    void Delete(Genre genre);
}