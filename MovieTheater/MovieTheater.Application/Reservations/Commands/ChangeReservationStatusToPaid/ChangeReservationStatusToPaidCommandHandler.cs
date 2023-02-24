using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;

namespace MovieTheater.Application.Reservations.Commands.ChangeReservationStatusToPaid;

public class ChangeReservationStatusToPaidCommandHandler: IRequestHandler<ChangeReservationStatusToPaidCommand, Unit>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public ChangeReservationStatusToPaidCommandHandler(
        IReservationRepository reservationRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ChangeReservationStatusToPaidCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken)
                          ?? throw new ReservationNotFoundException(request.Id);

        reservation.Paid = true;
        
        _reservationRepository.Update(reservation);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}