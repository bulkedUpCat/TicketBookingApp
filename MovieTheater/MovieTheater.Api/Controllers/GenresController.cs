using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Genres.Commands.CreateGenre;
using MovieTheater.Application.Genres.Commands.DeleteGenreCommand;
using MovieTheater.Application.Genres.Queries.GetAllGenres;
using MovieTheater.Application.Genres.Queries.GetGenreById;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController: ControllerBase
{
    private readonly IMediator _mediator;

    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllGenresQuery()));
    }

    [HttpGet("{id}", Name = nameof(GetGenreById))]
    public async Task<IActionResult> GetGenreById(Guid id)
    {
        return Ok(await _mediator.Send(new GetGenreByIdQuery() { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGenreCommand request)
    {
        var genre = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteGenreCommand() { Id = id });
        return NoContent();
    }
}