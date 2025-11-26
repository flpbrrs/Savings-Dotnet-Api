using Microsoft.AspNetCore.Diagnostics;
using Savings.Comunication.Responses;
using Savings.Exceptions;
using Savings.Exceptions.Bases;

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
            SavingsException ex => (
                ex.StatusCode,
                new ApiErrorResponseJson(ex.Message, ex.GetErrorList() ?? [])
            ),
            _ => (
                StatusCodes.Status500InternalServerError,
                new ApiErrorResponseJson(ResourceErrorMessages.UNEXPECTED_ERROR)
            )
        };

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}
