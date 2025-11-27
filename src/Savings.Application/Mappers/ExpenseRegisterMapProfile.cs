using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Domain.Entities;

namespace Savings.Application.Mappers;

public static class ExpenseRegisterMapProfile
{
    public static Expense ToEntity(this ExpenseRequestJson request)
    {
        return new Expense
        {
            Title = request.Title,
            Description = request.Description,
            Amount = request.Amount,
            Date = request.Date.ToUniversalTime(),
            ExpenseType = (Domain.Enums.ExpenseType) request.ExpenseType
        };
    }

    public static Expense ToEntityWithId(this ExpenseRequestJson request, long id)
    {
        return new Expense
        {
            Id = id,
            Title = request.Title,
            Description = request.Description,
            Amount = request.Amount,
            Date = request.Date.ToUniversalTime(),
            ExpenseType = (Domain.Enums.ExpenseType) request.ExpenseType
        };
    }

    public static RegisterExpenseResponseJson ToResponse(this Expense entity)
    {
        return new RegisterExpenseResponseJson
        {
            Id = entity.Id,
            Title = entity.Title
        };
    }
}
