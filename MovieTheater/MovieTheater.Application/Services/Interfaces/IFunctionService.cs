namespace MovieTheater.Application.Services.Interfaces;

public interface IFunctionService
{
    Task ChangeReservationStatusToCancelled(CancellationToken cancellationToken);
}