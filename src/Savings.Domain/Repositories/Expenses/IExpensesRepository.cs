using Savings.Domain.Entities;

namespace Savings.Domain.Repositories.Expenses;

public interface IExpensesRepository
{
    public Task Register(Expense expense);
}
