using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Services.Interfaces;

namespace MovieTheater.Application.Services;

public class FunctionService: IFunctionService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMovieTheaterDbContext _context;

    public FunctionService(
        IReservationRepository reservationRepository, 
        IMovieTheaterDbContext context)
    {
        _reservationRepository = reservationRepository;
        _context = context;
    }

    public async Task ChangeReservationStatusToCancelled(CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAllActive(cancellationToken);
        var updatedCount = 0;

        foreach (var reservation in reservations)
        {
            var screeningDate = reservation.Screening.Start;
            if (DateTime.UtcNow.AddMinutes(29) <= screeningDate) continue;
            
            //reservation.Status = ReservationStatus.Canceled;
            updatedCount++;
        }

        if (updatedCount != 0)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}