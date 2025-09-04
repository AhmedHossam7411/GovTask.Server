using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.Net;

public class ExceptionHandlingMiddleware : IExceptionHandler
{
    private readonly ILogger _logger;

    public ExceptionHandlingMiddleware(ILogger logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError($"Error occured while processing request ${exception.Message}");

        var problemDetails = new ProblemDetails
        {
            Title = exception.Message,
        };
        switch (exception)
        {
            case BadHttpRequestException:
                problemDetails.Title = exception.GetType().Name;
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                break;

            case UnauthorizedAccessException:
                problemDetails.Title = exception.GetType().Name;
                problemDetails.Status = (int)HttpStatusCode.Unauthorized;
                break;

            default:
                problemDetails.Title = "Internal Server Error";
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                break;
        }
        httpContext.Response.StatusCode = (int)problemDetails.Status;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}
