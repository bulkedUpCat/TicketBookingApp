using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Commands.EditMovie;

public class EditMovieCommandHandler: IRequestHandler<EditMovieCommand, MovieModel>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IProductionCompanyRepository _productionCompanyRepository;
    private readonly IProductionCountryRepository _productionCountryRepository;
    private readonly IMovieLanguageRepository _movieLanguageRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public EditMovieCommandHandler(
        IMovieRepository movieRepository, 
        IGenreRepository genreRepository,
        IProductionCompanyRepository productionCompanyRepository,
        IProductionCountryRepository productionCountryRepository,
        IMovieTheaterDbContext context, 
        IMapper mapper,
        IMovieLanguageRepository movieLanguageRepository)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
        _productionCompanyRepository = productionCompanyRepository;
        _productionCountryRepository = productionCountryRepository;
        _context = context;
        _mapper = mapper;
        _movieLanguageRepository = movieLanguageRepository;
    }
    
    public async Task<MovieModel> Handle(EditMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id, cancellationToken);

        if (movie == null)
        {
            throw new MovieNotFoundException(request.Id);
        }

        movie.Title = request.Title;
        movie.Description = request.Description;
        movie.DateReleased = request.DateReleased.AddDays(1);
        movie.Budget = request.Budget;
        movie.IMDbRating = request.IMDbRating;
        movie.Revenue = request.Revenue;
        movie.Poster = request.Poster;
        movie.DurationMinutes = request.DurationMinutes;

        if (request.Genres != null)
        {
            var genres = await _genreRepository
                .GetAllByIds(request.Genres, cancellationToken);
            movie.Genres = genres.ToList();
        }

        if (request.Countries != null)
        {
            var countries = await _productionCountryRepository
                .GetByIdsAsync(request.Countries, cancellationToken);
            movie.ProductionCountries = countries.ToList();
        }

        if (request.Languages != null)
        {
            var languages = await _movieLanguageRepository
                .GetByIdsAsync(request.Languages, cancellationToken);
            movie.MovieLanguages = languages.ToList();
        }

        if (request.ProductionCompany != Guid.Empty)
        {
            var productionCompany =
                await _productionCompanyRepository.GetByIdAsync(request.ProductionCompany, cancellationToken);
            movie.ProductionCompany = productionCompany;
        }

        _movieRepository.Update(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MovieModel>(movie);
    }
}