using Savings.Domain.Entities;
using Savings.Domain.Repositories.Expenses;

namespace Savings.Infrastructure.Database.Repositories;

internal class ExpensesRepository(SavingsDbContext _context) : IExpensesRepository
{
    public async Task Register(Expense expense)
    {
        _context.Expenses.Add(expense);

        await _context.SaveChangesAsync();
    }
}
