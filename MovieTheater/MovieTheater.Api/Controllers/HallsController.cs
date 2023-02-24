using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Halls.Commands.CreateHall;
using MovieTheater.Application.Halls.Commands.DeleteHall;
using MovieTheater.Application.Halls.Queries.GetAllHalls;
using MovieTheater.Application.Halls.Queries.GetHallById;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/halls")]
public class HallsController: ControllerBase
{
    private IMediator _mediator;

    public HallsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllHallsQuery()));
    }

    [HttpGet("{id}", Name = nameof(GetHallById))]
    public async Task<IActionResult> GetHallById(Guid id)
    {
        return Ok(await _mediator.Send(new GetHallByIdQuery() { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHallCommand request)
    {
        var hall = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetHallById), new { id = hall.Id }, hall);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteHallCommand() { Id = id });
        return NoContent();
    }
}