using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Reservation>> GetAllByUserId(string userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Reservation>> GetAllByScreeningId(Guid screeningId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Reservation>> GetAllActive(CancellationToken cancellationToken = default);
    Task<Reservation?> GetBySeatScreeningIds(Guid seatId, Guid screeningId, CancellationToken cancellationToken = default);
    Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<decimal>> GetIncomeByMovieId(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Reservation reservation, CancellationToken cancellationToken = default);
    void Update(Reservation reservation);
    void Delete(Reservation reservation);
}