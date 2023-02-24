using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetLatestMovies;

public class GetLatestMoviesQueryHandler: IRequestHandler<GetLatestMoviesQuery, IEnumerable<MovieModel>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetLatestMoviesQueryHandler(
        IMovieRepository movieRepository, 
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieModel>> Handle(GetLatestMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetLatestMoviesAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MovieModel>>(movies);
    }
}