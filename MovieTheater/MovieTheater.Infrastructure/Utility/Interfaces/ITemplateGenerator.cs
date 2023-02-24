namespace MovieTheater.Infrastructure.Utility.Interfaces;

public interface ITemplateGenerator
{
    Task<string> GetAllTicketsByReservationIdHtmlString(Guid reservationId, CancellationToken cancellationToken);
    Task<string> GetAllMoviesHtmlString();
}