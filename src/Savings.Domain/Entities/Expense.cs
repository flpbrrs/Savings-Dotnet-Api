using Savings.Domain.Enums;

namespace Savings.Domain.Entities;

public class Expense
{
    protected Expense() { }

    public Expense(string title, string? description, decimal amount, ExpenseType expenseType, DateTime date)
    {
        Title = title;
        Description = description;
        Amount = amount;
        ExpenseType = expenseType;
        Date = date;
    }

    public long Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public decimal Amount { get; private set; }
    public ExpenseType ExpenseType { get; private set; }
    public DateTime Date { get; private set; }

    public void Update(string title, string? description, decimal amount, ExpenseType expenseType, DateTime date)
    {
        Title = title;
        Description = description;
        Amount = amount;
        ExpenseType = expenseType;
        Date = date;
    }
}
