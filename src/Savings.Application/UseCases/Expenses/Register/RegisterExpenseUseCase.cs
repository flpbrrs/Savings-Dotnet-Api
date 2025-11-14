using Savings.Application.Abstractions;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IUseCase<RegisterExpenseRequestJson, RegisterExpenseResponseJson>
{
    private readonly List<string> validation = [];

    public Task<RegisterExpenseResponseJson> Execute(RegisterExpenseRequestJson request)
    {
        var validationResult = new RegisterExpenseValidador().Validate(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(
                [.. validationResult.Errors.Select(x => x.ErrorMessage)
            ]);
        }

        return Task.FromResult(new RegisterExpenseResponseJson
        {
            Title = request.Title!,
        });
    }
}
