using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TeamSync.Application.Common.Exceptions;
using static TeamSync.Application.Common.TeamSyncEnums;

namespace TeamSync.Api.Middlewares;

/// <summary>
/// Defines the global exception handling mechanism.
/// </summary>
public class GlobalExceptionHandler : IMiddleware
{
    /// <summary>
    /// Specifies the logger instance.
    /// </summary>
    private readonly ILogger<GlobalExceptionHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <seealso cref="GlobalExceptionHandler"/>
    /// </summary>
    /// <param name="logger"></param>
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Defines the invoke async method.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (TeamSyncException teamSyncException)
        {
            context.Response.StatusCode = (int)teamSyncException.HttpStatusCode;
            ProblemDetails problemDetails = new()
            {
                Status = (int)teamSyncException.HttpStatusCode,
                Title = nameof(teamSyncException.HttpStatusCode),
                Detail = teamSyncException.Message,
            };
            await HandleExceptionResponse(context, teamSyncException.Message, teamSyncException.StackTrace, problemDetails);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = (int)TeamSyncExceptionCodes.InternalServerError;
            ProblemDetails problemDetails = new()
            {
                Status = (int)TeamSyncExceptionCodes.InternalServerError,
                Title = nameof(TeamSyncExceptionCodes.InternalServerError),
            };
            await HandleExceptionResponse(context, e.Message, e.StackTrace, problemDetails);
        }
    }

    /// <summary>
    /// Handles the exception response.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="message"></param>
    /// <param name="stackTrace"></param>
    /// <param name="problemDetails"></param>
    /// <returns></returns>
    private async Task HandleExceptionResponse(HttpContext context, string message, string? stackTrace, ProblemDetails problemDetails)
    {
        string json = JsonSerializer.Serialize(problemDetails);
        context.Response.ContentType = "application/json";
        _logger.LogError("Error: {errorMessage}\nStackTrace: {stackTrace}", message, stackTrace);

        await context.Response.WriteAsync(json);
    }
}