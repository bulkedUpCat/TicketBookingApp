using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.MovieDirectors.Commands.CreateMovieDirector;
using MovieTheater.Application.MovieDirectors.Queries.GetAllMovieDirectors;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/movieDirectors")]
public class MovieDirectorsController: ControllerBase
{
    private readonly IMediator _mediator;

    public MovieDirectorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllMovieDirectorsQuery(), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMovieDirectorCommand request, CancellationToken cancellationToken)
    {
        var movieDirector = await _mediator.Send(request, cancellationToken);
        return Ok(movieDirector);
    }
}