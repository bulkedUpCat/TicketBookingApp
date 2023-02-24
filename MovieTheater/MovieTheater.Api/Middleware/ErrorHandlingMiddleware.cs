using System.Net;
using System.Text.Json;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Infrastructure.Exceptions.AuthException;

namespace MovieTheater.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = error switch
            {
                NotFoundException e => (int)HttpStatusCode.NotFound,
                AuthException e => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(error?.Message);
            await response.WriteAsync(result);
        }
    }
}