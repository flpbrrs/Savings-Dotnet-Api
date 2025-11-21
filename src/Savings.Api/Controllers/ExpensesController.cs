using Microsoft.AspNetCore.Mvc;
using Savings.Application.UseCases.Expenses.List;
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
    public async Task<IActionResult> Register(
        [FromServices] IRegisterExpenseUseCase _usecase,
        [FromBody] RegisterExpenseRequestJson request
    )
    {
        var result = await _usecase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpGet]
    [ProducesResponseType<PageResult<ListPageExpensesResponseJson>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ApiErrorResponseJson>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ApiErrorResponseJson>(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> List(
        [FromServices] IListExpensesUseCase _usecase,
        [FromQuery] ListPageExpensesRequestJson request
    )
    {
        var result = await _usecase.Execute(request);
        return Ok(result);
    }
}
