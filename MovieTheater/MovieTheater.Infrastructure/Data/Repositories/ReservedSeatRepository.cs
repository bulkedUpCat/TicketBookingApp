using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Reservations.Commands.CreateReservation;
using MovieTheater.Application.Shared.Movie;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class ReservedSeatRepository: IReservedSeatRepository
{
    private readonly IMovieTheaterDbContext _context;

    public ReservedSeatRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReservedSeat>> GetAllByScreeningId(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ReservedSeats
            .Include(s => s.Reservation)
            .Include(s => s.Seat)
            .Where(s => s.Reservation.ScreeningId == id)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<ReservedSeat>> GetAllByReservationId(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ReservedSeats
            .Include(s => s.Reservation)
            .Include(s => s.Seat)
            .Where(s => s.ReservationId == id)
            .ToListAsync(cancellationToken);
    }

    public async Task<ReservedSeat?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ReservedSeats
            .Include(rs => rs.Seat)
            .FirstOrDefaultAsync(rs => rs.Id == id, cancellationToken);
    }
    
    public async Task<IEnumerable<MovieIncomeModel>> GetMovieIncomeListAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ReservedSeats
            .Include(rs => rs.Reservation)
            .ThenInclude(r => r.Screening)
            .GroupBy(rs => rs.Reservation.Screening.Movie)
            .Select(g => new MovieIncomeModel { Movie = g.Key, Amount = 0 })
            .ToListAsync(cancellationToken);
    }

    public async Task CreateMany(IEnumerable<ReservedSeat> seats)
    {
        await _context.ReservedSeats.AddRangeAsync(seats);
    }
}