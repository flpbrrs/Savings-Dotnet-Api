using Microsoft.AspNetCore.Mvc;
using Savings.Application.UseCases.Expenses.Register;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Exceptions;

namespace Savings.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<RegisterExpenseResponseJson>(StatusCodes.Status201Created)]
    [ProducesResponseType<ApiErrorResponseJson>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ApiErrorResponseJson>(StatusCodes.Status500InternalServerError)]
    public IActionResult Register([FromBody] RegisterExpenseRequestJson request)
    {
        try
        {
            var result = new RegisterExpenseUseCase().Execute(request).Result;
            return Created(string.Empty, result);
        }
        catch (ValidationErrors ex)
        {
            return BadRequest(new ApiErrorResponseJson
            {
                Message = ex.Message,
                Errors = ex.Errors
            });
        }
        catch (Exception)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new ApiErrorResponseJson
                {
                    Message = "Um erro inesperado ocorreu. Tente mais tarde novamente.",
                    Errors = ["server.unknow-error"]
                }
            );
        }
    }
}
