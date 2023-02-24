namespace MovieTheater.Infrastructure.Utility.Interfaces;

public interface IPdfService
{
    Task<byte[]> GenerateTicketsAsync(Guid reservationId, CancellationToken cancellationToken = default);
    Task<byte[]> GenerateMoviesReport(CancellationToken cancellationToken = default);
}