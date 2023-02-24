using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.ReservedSeats.Queries.GetAllByScreeningId;
using MovieTheater.Application.ReservedSeats.Queries.GetReservedSeatById;
using MovieTheater.Application.ReservedSeats.Queries.GetReservedSeatsByReservationId;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/reservedSeats")]
public class ReservedSeatsController: ControllerBase
{
    private readonly IMediator _mediator;

    public ReservedSeatsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/api/screenings/{id}/reservedSeats")]
    public async Task<IActionResult> GetAllByScreeningId(Guid id, CancellationToken cancellationToken)
    {
        var reservedSeats = 
            await _mediator.Send(new GetAllReservedSeatsByScreeningIdQuery() { ScreeningId = id }, cancellationToken);

        return Ok(reservedSeats);
    }
    
    [HttpGet("/api/reservations/{id}/reservedSeats")]
    public async Task<IActionResult> GetAllByReservationId(Guid id, CancellationToken cancellationToken)
    {
        var reservedSeats =
            await _mediator.Send(new GetReservedSeatsByReservationIdQuery() { ReservationId = id }, cancellationToken);

        return Ok(reservedSeats);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _mediator.Send(new GetReservedSeatByIdQuery() { Id = id }));
    }
}