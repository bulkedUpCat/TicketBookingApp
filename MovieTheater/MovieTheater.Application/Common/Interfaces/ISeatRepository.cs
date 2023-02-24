using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface ISeatRepository
{
    Task<IEnumerable<Seat>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Seat>> GetAllByIds(Guid[] ids, CancellationToken cancellationToken = default);
    Task<IEnumerable<Seat>> GetAllByHallId(Guid hallId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Seat>> GetAllByHallAndScreeningIds(Guid hallId, Guid screeningId,
        CancellationToken cancellationToken = default);
    Task<Seat?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Seat seat, CancellationToken cancellationToken = default);
    void Delete(Seat seat);
}