using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Movie;
using MovieTheater.Domain.Models;

namespace MovieTheater.Application.Movies.Queries.GetMovieList;

public class GetMovieListQueryHandler: IRequestHandler<GetMovieListQuery, MovieListModel>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public GetMovieListQueryHandler(
        IMovieRepository movieRepository,
        IMovieTheaterDbContext context,
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<MovieListModel> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
    {
        var movieFilter = _mapper.Map<MovieFilter>(request);
        var movies = await _movieRepository.GetAllAsync(movieFilter, cancellationToken);
        var movieModels = _mapper.Map<IEnumerable<MovieModel>>(movies);

        var movieList = new MovieListModel()
        {
            Movies = movieModels
        };

        return movieList;
    }
}