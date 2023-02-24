using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetMostIncomeMovies;

public class GetMostIncomeMoviesQueryHandler: IRequestHandler<GetMostIncomeMoviesQuery, IEnumerable<MostIncomeModel>>
{
    private readonly IMovieRepository _movieRepository;
    public Task<IEnumerable<MostIncomeModel>> Handle(GetMostIncomeMoviesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}