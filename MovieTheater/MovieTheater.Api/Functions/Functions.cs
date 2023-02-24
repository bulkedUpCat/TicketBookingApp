/*using Microsoft.Azure.WebJobs;
using MovieTheater.Application.Services.Interfaces;

namespace MovieTheater.Api.Functions;

public class Functions
{
    private readonly IFunctionService _functionService;

    public Functions(IFunctionService functionService)
    {
        _functionService = functionService;
    }

    public async Task ChangeReservationStatusToCanceledAsync
        ([TimerTrigger("0 #1#1 * * * *")] TimerInfo timerInfo, CancellationToken cancellationToken)
    {
        await _functionService.ChangeReservationStatusToCancelled(cancellationToken);
    }
}*/
