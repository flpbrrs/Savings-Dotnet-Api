using Savings.Comunication.Enums;

namespace Savings.Comunication.Requests;

public class ExpenseRequestJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public ExpenseType ExpenseType { get; set; }
    public DateTime Date { get; set; }
}
