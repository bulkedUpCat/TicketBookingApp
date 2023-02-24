using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Seats.Queries.GetAllSeatsByHallId;

public class GetAllSeatsByHallIdQueryHandler: IRequestHandler<GetAllSeatsByHallIdQuery, IEnumerable<SeatModel>>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public GetAllSeatsByHallIdQueryHandler(
        ISeatRepository seatRepository, 
        IMapper mapper)
    {
        _seatRepository = seatRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<SeatModel>> Handle(GetAllSeatsByHallIdQuery request, CancellationToken cancellationToken)
    {
        var seats = await _seatRepository.GetAllByHallId(request.HallId, cancellationToken);
        return _mapper.Map<IEnumerable<SeatModel>>(seats);
    }
}