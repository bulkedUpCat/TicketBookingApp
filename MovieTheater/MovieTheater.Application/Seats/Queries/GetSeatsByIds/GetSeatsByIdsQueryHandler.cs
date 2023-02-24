using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Seats.Queries.GetSeatsByIds;

public class GetSeatsByIdsQueryHandler: IRequestHandler<GetSeatsByIdsQuery, IEnumerable<SeatModel>>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public GetSeatsByIdsQueryHandler(
        ISeatRepository seatRepository, 
        IMapper mapper)
    {
        _seatRepository = seatRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<SeatModel>> Handle(GetSeatsByIdsQuery request, CancellationToken cancellationToken)
    {
        var seats = await _seatRepository.GetAllByIds(request.Ids, cancellationToken);
        return _mapper.Map<IEnumerable<SeatModel>>(seats);
    }
}