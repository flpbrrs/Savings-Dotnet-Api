using FluentValidation;
using Savings.Comunication.Requests;

namespace Savings.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidador : AbstractValidator<RegisterExpenseRequestJson>
{
    public RegisterExpenseValidador()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("title.required");
        RuleFor(x => x.Title)
            .MinimumLength(4)
            .WithMessage("title.min-length-4");
        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("date.future");
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("amout.negative");
        RuleFor(x => x.ExpenseType)
            .IsInEnum()
            .WithMessage("type.invalid");
    }
}
