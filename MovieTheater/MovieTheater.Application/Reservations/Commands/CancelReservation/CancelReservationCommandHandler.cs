using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;

namespace MovieTheater.Application.Reservations.Commands.CancelReservation;

public class CancelReservationCommandHandler: IRequestHandler<CancelReservationCommand, Unit>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMovieTheaterDbContext _context;

    public CancelReservationCommandHandler(
        IReservationRepository reservationRepository, 
        IMovieTheaterDbContext context)
    {
        _reservationRepository = reservationRepository;
        _context = context;
    }

    public async Task<Unit> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken)
                          ?? throw new ReservationNotFoundException(request.ReservationId);
        
        _reservationRepository.Delete(reservation);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}