namespace Savings.Comunication.Responses;

public class ListPageExpensesResponseJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
}
