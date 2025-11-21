using FluentValidation;
using Savings.Comunication.Requests;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.List;

public class ListExpensesValidator : AbstractValidator<ListPageExpensesRequestJson>
{
    public ListExpensesValidator()
    {
        RuleFor(x => x.Number)
            .GreaterThan(0).WithMessage(ResourceErrorCodes.PAGE_NUMBER_IS_NEGATIVE);
        RuleFor(x => x.Size)
            .GreaterThan(0).WithMessage(ResourceErrorCodes.PAGE_SIZE_IS_NEGATIVE)
            .LessThanOrEqualTo(50).WithMessage(ResourceErrorCodes.PAGE_SIZE_IS_TOO_LONG);

        When(x => x.InitialDate.HasValue && x.FinalDate.HasValue, () => {
            RuleFor(x => x.FinalDate)
                .GreaterThanOrEqualTo(x => x.InitialDate).WithMessage(ResourceErrorCodes.FINAL_DATE_IN_PAST);
        });

        When(x => !string.IsNullOrWhiteSpace(x.Title), () => {
            RuleFor(x => x.Title)
                .MinimumLength(5).WithMessage(ResourceErrorCodes.SEARCH_TERM_TOO_SHORT);
        }); 
    }
}
