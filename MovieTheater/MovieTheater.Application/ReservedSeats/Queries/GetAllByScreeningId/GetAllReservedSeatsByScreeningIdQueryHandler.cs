using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.ReservedSeat;

namespace MovieTheater.Application.ReservedSeats.Queries.GetAllByScreeningId;

public class GetAllReservedSeatsByScreeningIdQueryHandler: IRequestHandler<GetAllReservedSeatsByScreeningIdQuery, IEnumerable<ReservedSeatModel>>
{
    private readonly IReservedSeatRepository _reservedSeatRepository;
    private readonly IMapper _mapper;

    public GetAllReservedSeatsByScreeningIdQueryHandler(
        IReservedSeatRepository reservedSeatRepository, 
        IMapper mapper)
    {
        _reservedSeatRepository = reservedSeatRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ReservedSeatModel>> Handle(GetAllReservedSeatsByScreeningIdQuery request, CancellationToken cancellationToken)
    {
        var reservedSeats = 
            await _reservedSeatRepository.GetAllByScreeningId(request.ScreeningId, cancellationToken);

        return _mapper.Map<IEnumerable<ReservedSeatModel>>(reservedSeats);
    }
}