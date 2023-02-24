using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetMovieById;

public class GetMovieByIdQueryHandler: IRequestHandler<GetMovieByIdQuery, MovieModel>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieByIdQueryHandler(
        IMovieRepository movieRepository,
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<MovieModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (movie == null)
        {
            throw new MovieNotFoundException(request.Id);
        }

        return _mapper.Map<MovieModel>(movie);
    }
}