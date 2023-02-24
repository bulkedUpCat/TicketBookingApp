using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.ReservedSeat;

namespace MovieTheater.Application.ReservedSeats.Queries.GetReservedSeatsByReservationId;

public class GetReservedSeatsByReservationIdQueryHandler: IRequestHandler<GetReservedSeatsByReservationIdQuery, IEnumerable<ReservedSeatModel>>
{
    private readonly IReservedSeatRepository _reservedSeatRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public GetReservedSeatsByReservationIdQueryHandler(
        IReservedSeatRepository reservedSeatRepository, 
        IReservationRepository reservationRepository, 
        IMapper mapper)
    {
        _reservedSeatRepository = reservedSeatRepository;
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ReservedSeatModel>> Handle(GetReservedSeatsByReservationIdQuery request, CancellationToken cancellationToken)
    {
        _ = await _reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken)
                          ?? throw new ReservationNotFoundException(request.ReservationId);

        var reservedSeats =
            await _reservedSeatRepository.GetAllByReservationId(request.ReservationId, cancellationToken);
        
        return _mapper.Map<IEnumerable<ReservedSeatModel>>(reservedSeats);
    }
}