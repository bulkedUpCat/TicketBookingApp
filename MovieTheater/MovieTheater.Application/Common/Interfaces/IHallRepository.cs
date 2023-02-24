using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IHallRepository
{
    Task<IEnumerable<Hall>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Hall?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Hall hall, CancellationToken cancellationToken = default);
    void Delete(Hall hall);
}