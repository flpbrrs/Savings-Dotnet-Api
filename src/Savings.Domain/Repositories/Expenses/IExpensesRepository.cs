using Savings.Domain.Criteria;
using Savings.Domain.Entities;

namespace Savings.Domain.Repositories.Expenses;

public interface IExpensesRepository
{
    public Task Register(Expense expense);
    public Task<(List<Expense> Expenses, int TotalCount)> List(ListExpensesCriteria criteria);
    public Task<Expense?> GetById(long id);
}
