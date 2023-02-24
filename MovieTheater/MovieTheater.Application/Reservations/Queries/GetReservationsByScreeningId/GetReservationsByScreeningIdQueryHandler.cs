using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Reservation;

namespace MovieTheater.Application.Reservations.Queries.GetReservationsByScreeningId;

public class GetReservationsByScreeningIdQueryHandler: IRequestHandler<GetReservationsByScreeningIdQuery, IEnumerable<ReservationModel>>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMapper _mapper;
    private readonly IMovieTheaterDbContext _context;

    public GetReservationsByScreeningIdQueryHandler(
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

    public async Task<IEnumerable<ReservationModel>> Handle(GetReservationsByScreeningIdQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAllByScreeningId(request.ScreeningId, cancellationToken);

        return _mapper.Map<IEnumerable<ReservationModel>>(reservations);
    }
}