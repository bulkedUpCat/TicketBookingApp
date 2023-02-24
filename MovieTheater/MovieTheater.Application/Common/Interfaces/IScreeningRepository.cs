using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IScreeningRepository
{
    Task<IEnumerable<Screening>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Screening>> GetAllByHallId(Guid hallId, CancellationToken cancellationToken = default);
    Task<Screening?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Screening screening, CancellationToken cancellationToken = default);
    void Delete(Screening screening);
}