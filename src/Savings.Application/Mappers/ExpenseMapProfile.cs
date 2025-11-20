using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Domain.Entities;

namespace Savings.Application.Mappers;

public static class ExpenseMapProfile
{
    public static Expense ToEntity(this RegisterExpenseRequestJson request)
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

    public static RegisterExpenseResponseJson ToResponse(this Expense entity)
    {
        return new RegisterExpenseResponseJson
        {
            Id = entity.Id,
            Title = entity.Title
        };
    }
    
    public static IList<RegisterExpenseResponseJson> ToResponseList(this IList<Expense> entities)
    {
        return [.. entities.Select(e => e.ToResponse())];
    }
}
