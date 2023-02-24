using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Movies.Queries.GetLastChanceMovies;
using MovieTheater.Application.Movies.Queries.GetLatestMovies;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticsController: ControllerBase
{
    private readonly IMediator _mediator;

    public StatisticsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("latest")]
    public async Task<IActionResult> GetLatestMovies(CancellationToken cancellationToken)
    {
        var movies = await _mediator.Send(new GetLatestMoviesQuery(), cancellationToken);
        return Ok(movies);
    }
    
    [HttpGet("lastChance")]
    public async Task<IActionResult> GetLastChanceMovies(CancellationToken cancellationToken)
    {
        var movies = await _mediator.Send(new GetLastChanceMoviesQuery(), cancellationToken);
        return Ok(movies);
    }
    
    [HttpGet("mostIncome")]
    public async Task<IActionResult> GetMostIncomeMovies(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}