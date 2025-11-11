using Savings.Application.Abstractions;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;

namespace Savings.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IUseCase<RegisterExpenseRequestJson, RegisterExpenseResponseJson>
{
    public Task<RegisterExpenseResponseJson> Execute(RegisterExpenseRequestJson request)
    {


        return Task.FromResult(new RegisterExpenseResponseJson
        {
            Title = request.Title,
        });
    }
}
