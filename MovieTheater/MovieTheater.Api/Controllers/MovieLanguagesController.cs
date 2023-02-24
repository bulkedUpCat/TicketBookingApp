using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.MovieLanguages.Commands.CreateMovieLanguage;
using MovieTheater.Application.MovieLanguages.Queries.GetAllMovieLanguages;
using MovieTheater.Application.MovieLanguages.Queries.GetAllMovieLanguagesByMovieId;
using MovieTheater.Application.MovieLanguages.Queries.GetMovieLanguageById;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/movieLanguages")]
public class MovieLanguagesController: ControllerBase
{
    private readonly IMediator _mediator;

    public MovieLanguagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllMovieLanguagesQuery(), cancellationToken));
    }

    [HttpGet("/api/movies/{id}/languages")]
    public async Task<IActionResult> GetAllByMovieId(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllMovieLanguagesByMovieIdQuery() {MovieId = id}, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetMovieLanguageByIdQuery { Id = id }, cancellationToken));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateMovieLanguageCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }
}