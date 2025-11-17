using FluentValidation;
using Savings.Comunication.Requests;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidador : AbstractValidator<RegisterExpenseRequestJson>
{
    public RegisterExpenseValidador()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ResourceErrorCodes.TITLE_REQUIRED)
            .MinimumLength(5).WithMessage(ResourceErrorCodes.TITLE_MIN_LENGHT);
        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorCodes.DATE_IN_FUTURE);
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage(ResourceErrorCodes.AMOUNT_ZERO_OR_NEGATIVE);
        RuleFor(x => x.ExpenseType)
            .IsInEnum().WithMessage(ResourceErrorCodes.EXPENSE_TYPE_INVALID);
    }
}
