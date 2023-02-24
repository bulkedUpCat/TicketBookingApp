using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Seats.Queries.GetSeatById;

public class GetSeatByIdQueryHandler: IRequestHandler<GetSeatByIdQuery, SeatModel>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public GetSeatByIdQueryHandler(
        ISeatRepository seatRepository, 
        IMapper mapper)
    {
        _seatRepository = seatRepository;
        _mapper = mapper;
    }
    
    public async Task<SeatModel> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
    {
        var seat = await _seatRepository.GetByIdAsync(request.Id, cancellationToken);

        if (seat == null)
        {
            throw new SeatNotFoundException(request.Id);
        }

        return _mapper.Map<SeatModel>(seat);
    }
}