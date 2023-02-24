using System.Text;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Infrastructure.Utility.Interfaces;

namespace MovieTheater.Infrastructure.Utility;

public class TemplateGenerator: ITemplateGenerator
{
    private readonly IReservedSeatRepository _reservedSeatRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IMovieRepository _movieRepository;

    public TemplateGenerator(
        IReservedSeatRepository reservedSeatRepository, 
        IReservationRepository reservationRepository,
        IMovieRepository movieRepository)
    {
        _reservedSeatRepository = reservedSeatRepository;
        _reservationRepository = reservationRepository;
        _movieRepository = movieRepository;
    }

    public async Task<string> GetAllTicketsByReservationIdHtmlString(
        Guid reservationId, 
        CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(reservationId, cancellationToken);

        if (reservation == null)
        {
            throw new ReservationNotFoundException(reservationId);
        }
        
        var reservedSeats = await _reservedSeatRepository
            .GetAllByReservationId(reservationId, cancellationToken);
        
        var sb = new StringBuilder();
        sb.Append($@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'>
                                    <h1>Your tickets</h1>
                                    <h1>Reservation id: {reservation.Id}</h1>
                                </div>
                                <table align='center'>
                                    <tr>
                                        <th>Screening</th>
                                        <th>Date</th>
                                        <th>Seat row</th>
                                        <th>Seat number</th>
                                    </tr>");
        foreach (var seat in reservedSeats)
        {
            sb.Append($@"<tr>
                                    <td>{reservation.Screening.Movie.Title}</td>
                                    <td>{reservation.Screening.Start:MM/dd/yyyy HH:mm}</td>
                                    <td>{seat.Seat.Row}</td>
                                    <td>{seat.Seat.Number}</td>
                                  </tr>");
        }
        sb.Append(@"
                                </table>
                            </body>
                        </html>");
        return sb.ToString();
    }

    public async Task<string> GetAllMoviesHtmlString()
    {
        var movies = await _movieRepository.GetMoviesWithScreeningsAsync();
        
        var sb = new StringBuilder();
        sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'>
                                    <h1>Movies</h1>
                                </div>
                                <table align='center'>
                                    <tr>
                                        <th>Title</th>
                                        <th>Description</th>
                                        <th>Screenings</th>
                                    </tr>");
        foreach (var movie in movies)
        {
            sb.Append($@"<tr>
                                    <td>{movie.Title}</td>
                                    <td>{movie.Description}</td>
                                    <td>");
            foreach (var screening in movie.Screenings)
            {
                sb.Append($@"<p>{screening.Start:MM/dd/yyyy HH:mm} {screening.Price}$</p>");
            }

            sb.Append($@"</td>
                         </tr>");
        }
        sb.Append(@"
                                </table>
                            </body>
                        </html>");
        return sb.ToString();
    }
}