using Savings.Domain.Entities;

namespace Savings.Domain.Repositories.Expenses;

public interface IUpdateOnlyExpensesRepository
{
    Task<Expense?> GetById(long id);
    void Update(Expense expense);
}
