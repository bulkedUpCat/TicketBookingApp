using MediatR;
using MovieTheater.Application.Shared.Genre;

namespace MovieTheater.Application.Genres.Queries.GetAllGenres;

public class GetAllGenresQuery: IRequest<IEnumerable<GenreModel>>
{
    
}