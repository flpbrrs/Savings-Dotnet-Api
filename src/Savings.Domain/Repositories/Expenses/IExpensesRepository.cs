using Savings.Domain.Entities;

namespace Savings.Domain.Repositories.Expenses;

public interface IExpensesRepository
{
    public Task Register(Expense expense);
    public Task<(List<Expense> Expenses, int TotalCount)> List(DateTime? initialDate, DateTime? finalDate, string? title, int page = 1, int pageSize = 10);
    public Task<Expense?> GetById(long id);
}
