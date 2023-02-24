using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Users.Queries.GetUserByIdQuery;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController: ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _mediator.Send(new GetUserByIdQuery() { Id = id }));
    }
}