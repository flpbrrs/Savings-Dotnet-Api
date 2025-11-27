using Savings.Application.Mappers;
using Savings.Comunication.Responses;
using Savings.Domain.Repositories.Expenses;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.GetById;

public class GetExpenseByIdUseCase(IReadOnlyExpensesRepository _expensesRepository) : IGetExpenseByIdUseCase
{
    public async Task<FullExpenseResponseJson> Execute(long id)
    {
        var expense = await _expensesRepository.GetById(id);

        return expense?.ToFullResponse() ?? throw new ResourceNotFoundException("expense", id);
    }
}
