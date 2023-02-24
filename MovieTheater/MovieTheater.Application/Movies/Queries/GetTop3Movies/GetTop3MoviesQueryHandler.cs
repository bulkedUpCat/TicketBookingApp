using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetTop3Movies;

public class GetTop3MoviesQueryHandler: IRequestHandler<GetTop3MoviesQuery,IEnumerable<MovieModel>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;
    
    public GetTop3MoviesQueryHandler(
        IMovieRepository movieRepository,
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<MovieModel>> Handle(GetTop3MoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetTop3MoviesAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MovieModel>>(movies);
    }
}