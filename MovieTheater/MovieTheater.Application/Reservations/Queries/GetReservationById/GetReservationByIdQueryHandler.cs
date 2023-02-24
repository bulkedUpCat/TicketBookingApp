using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Reservation;

namespace MovieTheater.Application.Reservations.Queries.GetReservationById;

public class GetReservationByIdQueryHandler: IRequestHandler<GetReservationByIdQuery, ReservationModel>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public GetReservationByIdQueryHandler(
        IReservationRepository reservationRepository,
        IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task<ReservationModel> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken)
                        ?? throw new ReservationNotFoundException(request.Id);
        
        return _mapper.Map<ReservationModel>(reservation);
    }
}