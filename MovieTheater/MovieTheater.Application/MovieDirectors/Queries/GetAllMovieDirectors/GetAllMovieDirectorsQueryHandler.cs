using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.MovieDirector;

namespace MovieTheater.Application.MovieDirectors.Queries.GetAllMovieDirectors;

public class GetAllMovieDirectorsQueryHandler: IRequestHandler<GetAllMovieDirectorsQuery, IEnumerable<MovieDirectorModel>>
{
    private readonly IMovieDirectorRepository _movieDirectorRepository;
    private readonly IMapper _mapper;

    public GetAllMovieDirectorsQueryHandler(
        IMovieDirectorRepository movieDirectorRepository, 
        IMapper mapper)
    {
        _movieDirectorRepository = movieDirectorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDirectorModel>> Handle(GetAllMovieDirectorsQuery request, CancellationToken cancellationToken)
    {
        var movieDirectors = await _movieDirectorRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MovieDirectorModel>>(movieDirectors);
    }
}