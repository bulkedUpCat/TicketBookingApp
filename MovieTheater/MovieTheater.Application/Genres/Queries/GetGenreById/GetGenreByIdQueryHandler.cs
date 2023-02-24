using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Genre;

namespace MovieTheater.Application.Genres.Queries.GetGenreById;

public class GetGenreByIdQueryHandler: IRequestHandler<GetGenreByIdQuery, GenreModel>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public GetGenreByIdQueryHandler(
        IGenreRepository genreRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _genreRepository = genreRepository;
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<GenreModel> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(request.Id, cancellationToken);

        if (genre == null)
        {
            throw new GenreNotFoundException(request.Id);
        }

        return _mapper.Map<GenreModel>(genre);
    }
}