using Savings.Application.Abstractions;
using Savings.Comunication.Requests;
using Savings.Domain.Repositories;
using Savings.Domain.Repositories.Expenses;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.Update;

public class UpdateExpenseUseCase(IUpdateOnlyExpensesRepository _repo, IUnitOfWork _unitOfWork) : IUpdateExpenseUseCase
{
    public async Task<Empty> Execute(UpdateExpenseRequestFilterJson request)
    {
        var validationResult = new ExpenseValidador().Validate(request.UpdatedExpense);

        if (!validationResult.IsValid)
            throw new ValidationException([.. validationResult.Errors.Select(x => x.ErrorMessage)]);

        var expense = await _repo.GetById(request.Id) ?? throw new ResourceNotFoundException("expense", request.Id);

        expense.Update(
            title: request.UpdatedExpense.Title,
            description: request.UpdatedExpense.Description,
            amount: request.UpdatedExpense.Amount,
            expenseType: (Domain.Enums.ExpenseType) request.UpdatedExpense.ExpenseType,
            date: request.UpdatedExpense.Date.ToUniversalTime()
        );

        _repo.Update(expense);

        await _unitOfWork.Commit();

        return Empty.Value;
    }
}
