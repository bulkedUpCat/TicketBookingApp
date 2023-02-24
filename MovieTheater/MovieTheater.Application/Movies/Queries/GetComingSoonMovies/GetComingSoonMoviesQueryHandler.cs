using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetComingSoonMovies;

public class GetComingSoonMoviesQueryHandler: IRequestHandler<GetComingSoonMoviesQuery, IEnumerable<MovieModel>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetComingSoonMoviesQueryHandler(
        IMovieRepository movieRepository, 
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieModel>> Handle(GetComingSoonMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetComingSoonMoviesAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MovieModel>>(movies);
    }
}