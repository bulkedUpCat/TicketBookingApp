using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class HallRepository: IHallRepository
{
    private readonly IMovieTheaterDbContext _context;

    public HallRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Hall>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Halls
            .FromSqlInterpolated<Hall>($"SELECT * FROM [Halls]")
            .ToListAsync(cancellationToken);
    }

    public async Task<Hall?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Halls
            .Include(h => h.Seats)
            .FirstOrDefaultAsync(h => h.Id == id, cancellationToken);

        /*return await _context.Halls
            .FromSqlInterpolated<Hall>(
                $"SELECT [t].[Id], [t].[Name], [s].[Id], [s].[HallId], [s].[Number], [s].[PriceOffset], [s].[Row] FROM (SELECT TOP(1) [h].[Id], [h].[Name] FROM [Halls] AS [h] WHERE [h].[Id] = {id}) AS [t] LEFT JOIN [Seats] AS [s] ON [t].[Id] = [s].[HallId]")
            .SingleOrDefaultAsync(cancellationToken);*/
    }

    public async Task CreateAsync(Hall hall, CancellationToken cancellationToken = default)
    {
        await _context.Halls.AddAsync(hall, cancellationToken);
    }

    public void Delete(Hall hall)
    {
        _context.Halls.Remove(hall);
        /*_context.Halls
            .FromSqlInterpolated($"DELETE FROM [Halls] WHERE [Id] = {hall.Id}");*/
    }
}