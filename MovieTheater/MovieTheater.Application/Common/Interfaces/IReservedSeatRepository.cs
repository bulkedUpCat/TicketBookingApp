using MovieTheater.Application.Shared.Movie;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IReservedSeatRepository
{
    Task<IEnumerable<ReservedSeat>> GetAllByScreeningId(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ReservedSeat>> GetAllByReservationId(Guid id, CancellationToken cancellationToken = default);
    Task<ReservedSeat?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<MovieIncomeModel>> GetMovieIncomeListAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateMany(IEnumerable<ReservedSeat> seats);
}