using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Seats.Queries.GetAllSeats;

public class GetAllSeatsQueryHandler: IRequestHandler<GetAllSeatsQuery, IEnumerable<SeatModel>>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public GetAllSeatsQueryHandler(
        ISeatRepository seatRepository, 
        IMapper mapper)
    {
        _seatRepository = seatRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SeatModel>> Handle(GetAllSeatsQuery request, CancellationToken cancellationToken)
    {
        var seats = await _seatRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SeatModel>>(seats);
    }
}