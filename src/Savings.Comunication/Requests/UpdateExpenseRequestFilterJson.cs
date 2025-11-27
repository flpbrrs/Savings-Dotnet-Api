namespace Savings.Comunication.Requests;

public class UpdateExpenseRequestFilterJson
{
    public required long Id { get; set; }
    public required ExpenseRequestJson UpdatedExpense { get; set; }
}
