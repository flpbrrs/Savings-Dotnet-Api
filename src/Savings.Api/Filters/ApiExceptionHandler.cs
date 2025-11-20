using Microsoft.AspNetCore.Diagnostics;
using Savings.Comunication.Responses;
using Savings.Exceptions;

namespace Savings.Api.Filters;

public class ApiExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        var (statusCode, response) = exception switch
        {
            ValidationException ex => (StatusCodes.Status400BadRequest, new ApiErrorResponseJson(ex.Message, ex.Errors)),
            _ => (StatusCodes.Status500InternalServerError, new ApiErrorResponseJson(ResourceErrorMessages.UNEXPECTED_ERROR))
        };

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}
