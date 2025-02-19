using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecruitmentSystem.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,      // 404
                ArgumentException => (int)HttpStatusCode.BadRequest,      // 400
                InvalidOperationException => (int)HttpStatusCode.Conflict, // 409
                _ => (int)HttpStatusCode.InternalServerError              // 500
            };

            var response = new
            {
                message = exception.Message,
                statusCode = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
