using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class SeatRepository: ISeatRepository
{
    private readonly IMovieTheaterDbContext _context;

    public SeatRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seat>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Seats
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Seat>> GetAllByIds(Guid[] ids, CancellationToken cancellationToken = default)
    {
        return await _context.Seats
            .Where(s => ids.Any(id => id == s.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Seat>> GetAllByHallId(Guid hallId, CancellationToken cancellationToken = default)
    {
        return await _context.Seats
            .Where(s => s.HallId == hallId)
            .Include(s => s.ReservedSeats)
            .ThenInclude(rs => rs.Reservation)
            .ToListAsync(cancellationToken);
    }

    public Task<IEnumerable<Seat>> GetAllByHallAndScreeningIds(Guid hallId, Guid screeningId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Seat?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Seats
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task CreateAsync(Seat seat, CancellationToken cancellationToken = default)
    {
        await _context.Seats.AddAsync(seat, cancellationToken);
    }

    public void Delete(Seat seat)
    {
        _context.Seats.Remove(seat);
    }
}