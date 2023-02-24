using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Seats.Queries.GetAllSeatsByHallId;
using MovieTheater.Application.Seats.Queries.GetSeatsByIds;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/halls")]
public class SeatsController: ControllerBase
{
    private readonly IMediator _mediator;

    public SeatsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/api/seats")]
    public async Task<IActionResult> GetAllByIds([FromQuery] GetSeatsByIdsQuery request)
    {
        var seats = await _mediator.Send(request);
        return Ok(seats);
    }

    [HttpGet("{id}/seats")]
    public async Task<IActionResult> GetAllByHallId(Guid id)
    {
        var seats = await _mediator.Send(new GetAllSeatsByHallIdQuery() { HallId = id });
        return Ok(seats);
    }
}