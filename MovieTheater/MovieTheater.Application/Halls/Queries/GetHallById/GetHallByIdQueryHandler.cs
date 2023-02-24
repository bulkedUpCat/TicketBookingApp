using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Hall;

namespace MovieTheater.Application.Halls.Queries.GetHallById;

public class GetHallByIdQueryHandler: IRequestHandler<GetHallByIdQuery, HallModel>
{
    private readonly IHallRepository _hallRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public GetHallByIdQueryHandler(
        IHallRepository hallRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _hallRepository = hallRepository;
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<HallModel> Handle(GetHallByIdQuery request, CancellationToken cancellationToken)
    {
        var hall = await _hallRepository.GetByIdAsync(request.Id, cancellationToken);

        if (hall == null)
        {
            throw new HallNotFoundException(request.Id);
        }

        return _mapper.Map<HallModel>(hall);
    }
}