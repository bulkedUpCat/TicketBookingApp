namespace MovieTheater.Infrastructure.Utility.Interfaces;

public interface IEmailService
{
    Task SendMoviesReportAsync(string to, CancellationToken cancellationToken);
    Task SendTicketsReportAsync(string to, Guid reservationId, CancellationToken cancellationToken);
}