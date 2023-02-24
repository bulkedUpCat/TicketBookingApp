using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Reservation;

namespace MovieTheater.Application.Reservations.Queries.GetReservationByReservedSeatId;

public class GetReservationBySeatScreeningIdsQueryHandler: IRequestHandler<GetReservationBySeatScreeningIdsQuery, ReservationModel>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMapper _mapper;
    private readonly IMovieTheaterDbContext _context;

    public GetReservationBySeatScreeningIdsQueryHandler(
        IReservationRepository reservationRepository, 
        IScreeningRepository screeningRepository,
        IMapper mapper, 
        IMovieTheaterDbContext context)
    {
        _reservationRepository = reservationRepository;
        _screeningRepository = screeningRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<ReservationModel> Handle(GetReservationBySeatScreeningIdsQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetBySeatScreeningIds(request.SeatId, request.ScreeningId, cancellationToken)
                        ?? throw new ReservationNotFoundException();

        return _mapper.Map<ReservationModel>(reservation);
    }
}