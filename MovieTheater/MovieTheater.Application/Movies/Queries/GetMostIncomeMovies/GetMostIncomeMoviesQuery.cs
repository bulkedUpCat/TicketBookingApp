using MediatR;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetMostIncomeMovies;

public class GetMostIncomeMoviesQuery: IRequest<IEnumerable<MostIncomeModel>>
{
    
}