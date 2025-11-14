using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Savings.Comunication.Responses;
using Savings.Exceptions;
using Savings.Exceptions.Bases;

namespace Savings.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is SavingsException) HandleApiException(context);
        else ThrowUnknowException(context);
    }

    private static void HandleApiException(ExceptionContext context)
    {
        switch (context.Exception) 
        {
            case ValidationException ex:
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(
                    new ApiErrorResponseJson(
                        message: ex.Message,
                        errors: ex.Errors
                    )
                );
                break;
            default:
                ThrowUnknowException (context);
                break;
        }
    }
    private static void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ApiErrorResponseJson("Um erro inesperado ocorreu. Tente mais tarde novamente."));
    }
}
