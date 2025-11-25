using Savings.Domain.Exceptions;

namespace Savings.Domain.ValueObjects;

public class DateRange
{
    public DateTime? InitialDate { get; }
    public DateTime? FinalDate { get; }
    public DateRange(DateTime? initialDate, DateTime? finalDate)
    {
        if (initialDate is not null && finalDate is not null && initialDate > finalDate)
            throw new DomainException("data-range.invalid");

        InitialDate = initialDate;
        FinalDate = finalDate;
    }
}
