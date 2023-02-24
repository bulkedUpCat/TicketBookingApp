using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetLastChanceMovies;

public class GetLastChanceMoviesQueryHandler: IRequestHandler<GetLastChanceMoviesQuery, IEnumerable<MovieModel>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetLastChanceMoviesQueryHandler(
        IMovieRepository movieRepository, 
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieModel>> Handle(GetLastChanceMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetLastChanceMoviesAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MovieModel>>(movies);
    }
}