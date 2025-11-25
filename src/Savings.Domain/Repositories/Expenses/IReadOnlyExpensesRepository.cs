using Savings.Domain.Criteria;
using Savings.Domain.Entities;

namespace Savings.Domain.Repositories.Expenses;

public interface IReadOnlyExpensesRepository
{
    public Task<Expense?> GetById(long id);

    public Task<(List<Expense> Expenses, int TotalCount)> List(ListExpensesCriteria criteria);
}
