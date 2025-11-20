using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Domain.Entities;
using Savings.Domain.Enums;
using Savings.Domain.Repositories.Expenses;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase(IExpensesRepository _expensesRepository) : IRegisterExpenseUseCase
{
    public async Task<RegisterExpenseResponseJson> Execute(RegisterExpenseRequestJson request)
    {
        var validationResult = new RegisterExpenseValidador().Validate(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(
                [.. validationResult.Errors.Select(x => x.ErrorMessage)
            ]);
        }

        var expense = new Expense 
        {
            Title = request.Title,
            Description = request.Description,
            Amount = request.Amount,
            Date = request.Date.ToUniversalTime(),
            ExpenseType = (ExpenseType) request.ExpenseType
        };

        await _expensesRepository.Register(expense);

        return new RegisterExpenseResponseJson
        {
            Title = expense.Title,
        };
    }
}
