using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Genre;

namespace MovieTheater.Application.Genres.Queries.GetAllGenres;

public class GetAllGenresQueryHandler: IRequestHandler<GetAllGenresQuery, IEnumerable<GenreModel>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public GetAllGenresQueryHandler(
        IGenreRepository genreRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _genreRepository = genreRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreModel>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _genreRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<IEnumerable<GenreModel>>(genres);
    }
}