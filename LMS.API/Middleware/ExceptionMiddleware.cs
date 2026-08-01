using System.Net;
using System.Text.Json;
using LMS.Shared.Responses;

namespace LMS.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                ex.Message);

            await HandleExceptionAsync(
                context,
                ex);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType =
            "application/json";

        context.Response.StatusCode =
            (int)HttpStatusCode.InternalServerError;

        var response =
            ApiResponse<object>.FailResult(
                "An unexpected error occurred.");

        response.Errors.Add(
            new ApiError
            {
                Code = "SERVER_ERROR",
                Description = exception.Message
            });

        var json =
            JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}