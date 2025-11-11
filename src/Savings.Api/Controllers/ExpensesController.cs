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
    [ProducesResponseType(typeof(RegisterExpenseResponseJson),StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RegisterExpenseRequestJson request)
    {
        var result = new RegisterExpenseUseCase().Execute(request).Result;
        return Created(string.Empty, result);
    }
}
