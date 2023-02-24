using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.ReservedSeat;

namespace MovieTheater.Application.ReservedSeats.Queries.GetReservedSeatById;

public class GetReservedSeatByIdQueryHandler: IRequestHandler<GetReservedSeatByIdQuery, ReservedSeatModel>
{
    private readonly IReservedSeatRepository _reservedSeatRepository;
    private readonly IMapper _mapper;

    public GetReservedSeatByIdQueryHandler(
        IReservedSeatRepository reservedSeatRepository, 
        IMapper mapper)
    {
        _reservedSeatRepository = reservedSeatRepository;
        _mapper = mapper;
    }

    public async Task<ReservedSeatModel> Handle(GetReservedSeatByIdQuery request, CancellationToken cancellationToken)
    {
        var reservedSeat = await _reservedSeatRepository.GetByIdAsync(request.Id, cancellationToken);

        if (reservedSeat == null)
        {
            throw new ReservedSeatNotFoundException(request.Id);
        }

        return _mapper.Map<ReservedSeatModel>(reservedSeat);
    }
}