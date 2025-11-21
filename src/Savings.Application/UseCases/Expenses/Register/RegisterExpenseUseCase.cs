using Savings.Application.Mappers;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Domain.Entities;
using Savings.Domain.Repositories;
using Savings.Domain.Repositories.Expenses;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase(IExpensesRepository _expensesRepository, IUnitOfWork _UoW) : IRegisterExpenseUseCase
{
    public async Task<RegisterExpenseResponseJson> Execute(RegisterExpenseRequestJson request)
    {
        var validationResult = new RegisterExpenseValidador().Validate(request);

        if (!validationResult.IsValid)
            throw new ValidationException([.. validationResult.Errors.Select(x => x.ErrorMessage)]);

        Expense expense = request.ToEntity();

        await _expensesRepository.Register(expense);

        await _UoW.Commit();

        return expense.ToResponse();
    }
}
