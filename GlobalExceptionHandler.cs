using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = exception switch
        {
            ArgumentException => (int)HttpStatusCode.BadRequest,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var response = new
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = exception.Message
        };

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response), cancellationToken);
        return true; // Indicate that the exception was handled
    }
}
