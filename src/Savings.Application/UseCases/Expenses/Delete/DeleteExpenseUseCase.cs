using Savings.Application.Abstractions;
using Savings.Domain.Repositories;
using Savings.Domain.Repositories.Expenses;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.Delete;

public class DeleteExpenseUseCase(
    IWriteOnlyExpensesRepository _writeRepo,
    IUnitOfWork _unitOfWork
) : IDeleteExpenseUseCase
{
    public async Task<Empty> Execute(long request)
    {
        var canDelete = await _writeRepo.Delete(request);

        if (!canDelete)
            throw new ResourceNotFoundException("expense", request);

        await _unitOfWork.Commit();

        return Empty.Value;
    }
}
