using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.BadRequestException;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Reservation;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandHandler: IRequestHandler<CreateReservationCommand, ReservationModel>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IReservedSeatRepository _reservedSeatRepository;
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMapper _mapper;
    private readonly IMovieTheaterDbContext _context;

    public CreateReservationCommandHandler(
        IReservationRepository reservationRepository,
        IReservedSeatRepository reservedSeatRepository,
        IScreeningRepository screeningRepository,
        IMapper mapper,
        IMovieTheaterDbContext context)
    {
        _reservationRepository = reservationRepository;
        _reservedSeatRepository = reservedSeatRepository;
        _screeningRepository = screeningRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReservationModel> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var screening = await _screeningRepository.GetByIdAsync(request.ScreeningId, cancellationToken)
                        ?? throw new ScreeningNotFoundException(request.ScreeningId);

        if (screening.Start < DateTime.UtcNow.AddMinutes(30))
        {
            throw new BookingUnavailableException(
                "Screening is to start in 30 minutes. Cannot book tickets anymore. Go buy them in person");
        }
        
        var reservation = _mapper.Map<Reservation>(request);
        reservation.ValidTo = screening.Start.AddMinutes(-30);

        await _reservationRepository.CreateAsync(reservation, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        var reservedSeats = 
            request.SeatIds.Select(seatId => new ReservedSeat { ReservationId = reservation.Id, SeatId = seatId }).ToList();

        await _reservedSeatRepository.CreateMany(reservedSeats);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ReservationModel>(reservation);
    }
}