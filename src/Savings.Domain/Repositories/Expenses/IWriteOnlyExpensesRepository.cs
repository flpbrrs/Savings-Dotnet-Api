using Savings.Domain.Entities;

namespace Savings.Domain.Repositories.Expenses;

public interface IWriteOnlyExpensesRepository
{
    public Task Register(Expense expense);
    public Task<bool> Delete(long id);
}
