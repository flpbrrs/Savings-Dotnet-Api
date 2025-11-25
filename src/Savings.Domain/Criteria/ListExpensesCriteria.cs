using Savings.Domain.ValueObjects;

namespace Savings.Domain.Criteria;

public class ListExpensesCriteria
{
    public string? Title { get; set; }
    public DateRange? DateRange { get; set; }
    public required Pagination Pagination { get; set; }
}
