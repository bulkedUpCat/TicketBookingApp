using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Hall;

namespace MovieTheater.Application.Halls.Queries.GetAllHalls;

public class GetAllHallsQueryHandler: IRequestHandler<GetAllHallsQuery, IEnumerable<HallModel>>
{
    private readonly IHallRepository _hallRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public GetAllHallsQueryHandler(
        IHallRepository hallRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _hallRepository = hallRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HallModel>> Handle(GetAllHallsQuery request, CancellationToken cancellationToken)
    {
        var halls = await _hallRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<HallModel>>(halls);
    }
}