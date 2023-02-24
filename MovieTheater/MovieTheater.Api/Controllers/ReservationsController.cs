using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Reservations.Commands.CancelReservation;
using MovieTheater.Application.Reservations.Commands.ChangeReservationStatusToPaid;
using MovieTheater.Application.Reservations.Commands.CreateReservation;
using MovieTheater.Application.Reservations.Queries.GetReservationById;
using MovieTheater.Application.Reservations.Queries.GetReservationByReservedSeatId;
using MovieTheater.Application.Reservations.Queries.GetReservationsByScreeningId;
using MovieTheater.Application.Reservations.Queries.GetReservationsByUserId;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Api.Controllers;

[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/reservations")]
public class ReservationsController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IReservedSeatRepository _reservedSeatRepository;

    public ReservationsController(
        IMediator mediator, 
        IReservedSeatRepository reservedSeatRepository)
    {
        _mediator = mediator;
        _reservedSeatRepository = reservedSeatRepository;
    }

    [HttpGet("/api/screenings/{id}/reservations")]
    public async Task<IActionResult> GetByScreeningId(Guid id)
    {
        return Ok(await _mediator.Send(new GetReservationsByScreeningIdQuery() { ScreeningId = id }));
    }

    [HttpGet("/api/users/{id}/reservations")]
    public async Task<IActionResult> GetByUserId(string id)
    {
        return Ok(await _mediator.Send(new GetReservationsByUserIdQuery() { UserId = id }));
    }

    [HttpGet("/api/screenings/{screeningId}/reservations/seats/{seatId}")]
    public async Task<IActionResult> GeBySeatScreeningIds(
        Guid screeningId, 
        Guid seatId)
    {
        return Ok(await _mediator.Send(new GetReservationBySeatScreeningIdsQuery()
            { SeatId = seatId, ScreeningId = screeningId }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetReservationByIdQuery() { Id = id }, cancellationToken));
    }

    [HttpPost("/api/screenings/reservations")]
    public async Task<IActionResult> Create(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _mediator.Send(request, cancellationToken);
        return Ok(reservation);
    }

    [HttpPut("{id}/pay")]
    public async Task<IActionResult> ChangeStatusToPaid(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ChangeReservationStatusToPaidCommand() { Id = id }, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Cancel(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CancelReservationCommand() { ReservationId = id }, cancellationToken);
        return NoContent();
    }
}