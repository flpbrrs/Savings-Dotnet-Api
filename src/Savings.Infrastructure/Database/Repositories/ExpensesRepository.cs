using Microsoft.EntityFrameworkCore;
using Savings.Domain.Criteria;
using Savings.Domain.Entities;
using Savings.Domain.Repositories.Expenses;

namespace Savings.Infrastructure.Database.Repositories;

internal class ExpensesRepository(SavingsDbContext _context) : IReadOnlyExpensesRepository, IWriteOnlyExpensesRepository
{
    public Task<Expense?> GetById(long id)
    {
        return _context.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<(List<Expense> Expenses, int TotalCount)> List(ListExpensesCriteria criteria)
    {
        var query = _context.Expenses.AsNoTracking();

        if (criteria.DateRange is not null)
        {
            if (criteria.DateRange.InitialDate.HasValue)
                query = query.Where(e => e.Date >= criteria.DateRange.InitialDate.Value);

            if (criteria.DateRange.FinalDate.HasValue)
            {
                var endOfDay = criteria.DateRange.FinalDate.Value.AddDays(1).AddTicks(-1);
                query = query.Where(e => e.Date <= endOfDay);
            }
        }

        if(!string.IsNullOrWhiteSpace(criteria.Title))
            query = query.Where(e => e.Title.Contains(criteria.Title));

        int totalCount = await query.CountAsync();

        var expenseList = await query
            .OrderByDescending(e => e.Date)
            .Skip((criteria.Pagination.Page - 1) * criteria.Pagination.PageSize)
            .Take(criteria.Pagination.PageSize)
            .ToListAsync();

        return (expenseList, totalCount);
    }

    public async Task Register(Expense expense)
    {
        _context.Expenses.Add(expense);
    }

    public async Task<bool> Delete(long id)
    {
        var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);

        if (expense is null) return false;

        _context.Expenses.Remove(expense);

        return true;
    }
}
