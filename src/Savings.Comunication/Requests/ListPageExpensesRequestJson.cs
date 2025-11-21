namespace Savings.Comunication.Requests;

public class ListPageExpensesRequestJson
{
    public int Number { get; set; } = 1;
    public int Size { get; set; } = 10;
    public DateTime? InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }
    public string? Title { get; set; } = string.Empty;
}
