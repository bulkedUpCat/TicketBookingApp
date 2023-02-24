using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Api.Services;
using MovieTheater.Application.Movies.Commands.CreateMovie;
using MovieTheater.Application.Movies.Commands.DeleteMovie;
using MovieTheater.Application.Movies.Commands.EditMovie;
using MovieTheater.Application.Movies.Queries.GetComingSoonMovies;
using MovieTheater.Application.Movies.Queries.GetMovieById;
using MovieTheater.Application.Movies.Queries.GetMovieList;
using MovieTheater.Application.Movies.Queries.GetTop3Movies;
using MovieTheater.Application.Shared.Movie;
using MovieTheater.Infrastructure.Utility;
using MovieTheater.Infrastructure.Utility.Interfaces;
using MovieTheater.Infrastructure.Utility.Models;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly MovieMicroservice _movieMicroService;
    private readonly IMapper _mapper;
    private readonly IRawQueryService _rawQueryService;

    public MoviesController(
        IMediator mediator, 
        MovieMicroservice movieMicroService,
        IMapper mapper, 
        IRawQueryService rawQueryService)
    {
        _mediator = mediator;
        _movieMicroService = movieMicroService;
        _mapper = mapper;
        _rawQueryService = rawQueryService;
    }

    [HttpGet("/api/external/movies")]
    public async Task<IActionResult> FetchMovies()
    {
        var movies = await _movieMicroService.FetchMovies();
        return Ok(_mapper.Map<IEnumerable<MovieModel>>(movies));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GetMovieListQuery request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet("top3")]
    public async Task<IActionResult> GetTop3(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetTop3MoviesQuery(),cancellationToken));
    }

    [HttpGet("comingSoon")]
    public async Task<IActionResult> GetComingSoon(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetComingSoonMoviesQuery(), cancellationToken));
    }

    [HttpGet("{id}", Name = nameof(GetMovieById))]
    public async Task<IActionResult> GetMovieById(
        Guid id, 
        CancellationToken cancellationToken)
    {
        var movie = await _mediator.Send(new GetMovieByIdQuery() { Id = id }, cancellationToken);
        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateMovieCommand request, 
        CancellationToken cancellationToken)
    {
        var movie = await _mediator.Send(request, cancellationToken);
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(
        Guid id, 
        EditMovieCommand request)
    {
        request.Id = id;
        var movie = await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        await _mediator.Send(new DeleteMovieCommand() { Id = id });
        return NoContent();
    }

    [HttpPost("raw")]
    public async Task<IActionResult> ExecuteRawQuery(RawQueryModel model)
    {
        var res = await _rawQueryService.ExecuteRawQuery(model.Query);
        return Ok(res);
    }
}