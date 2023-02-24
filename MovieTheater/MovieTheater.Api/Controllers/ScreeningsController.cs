using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Screenings.Commands.CreateScreening;
using MovieTheater.Application.Screenings.Commands.DeleteScreening;
using MovieTheater.Application.Screenings.Queries.GetScreeningById;
using MovieTheater.Application.Screenings.Queries.GetScreeningsByHallId;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/halls")]
public class ScreeningsController: ControllerBase
{
    private readonly IMediator _mediator;

    public ScreeningsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}/screenings")]
    public async Task<IActionResult> GetScreeningsByHallId(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetScreeningsByHallIdQuery() { HallId = id }, cancellationToken));
    }

    [HttpGet("/api/screenings/{id}")]
    public async Task<IActionResult> GetScreeningById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetScreeningByIdQuery() { Id = id }, cancellationToken));
    }

    [HttpPost("screenings")]
    public async Task<IActionResult> Create(CreateScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = await _mediator.Send(request, cancellationToken);
        return Ok(screening);
    }

    [HttpDelete("/api/screenings/{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteScreeningCommand { Id = id }, cancellationToken);
        return NoContent();
    }
}