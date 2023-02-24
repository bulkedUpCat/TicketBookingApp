using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class ReservationRepository: IReservationRepository
{
    private readonly IMovieTheaterDbContext _context;

    public ReservationRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Reservations
            .Include(r => r.Screening)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Reservation>> GetAllByUserId(string userId, CancellationToken cancellationToken = default)
    {
        return await _context.Reservations
            .Include(r => r.Screening)
            .Where(r => r.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Reservation>> GetAllByScreeningId(Guid screeningId, CancellationToken cancellationToken = default)
    {
        return await _context.Reservations
            .Include(r => r.Screening)
            .Where(r => r.ScreeningId == screeningId && !r.Paid)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Reservation>> GetAllActive(CancellationToken cancellationToken = default)
    {
        return await _context.Reservations
            .Include(r => r.Screening)
            .ToListAsync(cancellationToken);
    }

    public async Task<Reservation?> GetBySeatScreeningIds(Guid seatId, Guid screeningId, CancellationToken cancellationToken = default)
    {
        return await _context.Reservations
            .Include(r => r.ReservedSeats)
            .Where(r => r.ScreeningId == screeningId)
            .FirstOrDefaultAsync(r => r.ReservedSeats.FirstOrDefault(rs => rs.SeatId == seatId) != null, cancellationToken);
    }

    public async Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Reservations
            .Include(r => r.Screening)
            .ThenInclude(s => s.Movie)
            .Include(r => r.ReservedSeats)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<decimal>> GetIncomeByMovieId(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Reservations
            .Include(r => r.Screening)
            .Include(r => r.ReservedSeats)
            .GroupBy(r => r.Screening)
            .Select(g => g.Select(r => r.ReservedSeats).Count() * g.Key.Price)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(Reservation reservation, CancellationToken cancellationToken = default)
    {
        await _context.Reservations.AddAsync(reservation, cancellationToken);
    }

    public void Update(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
    }

    public void Delete(Reservation reservation)
    {
        _context.Reservations.Remove(reservation);
    }
}