using Microsoft.EntityFrameworkCore;
using Savings.Domain.Entities;
using Savings.Domain.Repositories.Expenses;

namespace Savings.Infrastructure.Database.Repositories;

internal class ExpensesRepository(SavingsDbContext _context) : IExpensesRepository
{
    public Task<Expense?> GetById(long id)
    {
        return _context.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<(List<Expense> Expenses, int TotalCount)> List(
        DateTime? initialDate,
        DateTime? finalDate,
        string? title,
        int page = 1,
        int pageSize = 10
    )
    {
        var query = _context.Expenses.AsNoTracking();

        if (initialDate.HasValue)
            query = query.Where(e => e.Date >= initialDate.Value);

        if (finalDate.HasValue)
        {
            var endOfDay = finalDate.Value.AddDays(1).AddTicks(-1);
            query = query.Where(e => e.Date <= endOfDay);
        }

        if(!string.IsNullOrWhiteSpace(title))
            query = query.Where(e => e.Title.Contains(title));

        int totalCount = await query.CountAsync();

        if (page < 1) page = 1;

        var expenseList = await query
            .OrderByDescending(e => e.Date)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (expenseList, totalCount);
    }

    public async Task Register(Expense expense)
    {
        _context.Expenses.Add(expense);
    }
}
