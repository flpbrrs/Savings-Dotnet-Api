using Savings.Comunication.Requests;
using Bogus;
using Savings.Comunication.Enums;

namespace CommonUtilitiesTest.Request;

public class RegisterExpenseRequestJsonBuilder
{
    public static RegisterExpenseRequestJson Build()
    {
        return new Faker<RegisterExpenseRequestJson>()
            .StrictMode(true)
            .RuleFor(r => r.Title, f => f.Commerce.ProductName())
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.Amount, f => f.Finance.Amount())
            .RuleFor(r => r.Date, f => f.Date.Past())
            .RuleFor(r => r.ExpenseType, f => f.PickRandom<ExpenseType>());
    }
}
