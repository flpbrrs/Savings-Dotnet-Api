using Microsoft.AspNetCore.Mvc;
using Savings.Application.UseCases.Expenses.Register;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;

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
        var result = new RegisterExpenseUseCase().Execute(request).Result;
        return Created(string.Empty, result);
    }
}
