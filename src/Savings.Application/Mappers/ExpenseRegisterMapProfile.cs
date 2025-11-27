using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Domain.Criteria;
using Savings.Domain.Entities;
using Savings.Domain.ValueObjects;
using System.Globalization;

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

    public static RegisterExpenseResponseJson ToResponse(this Expense entity)
    {
        return new RegisterExpenseResponseJson
        {
            Id = entity.Id,
            Title = entity.Title
        };
    }

    public static FullExpenseResponseJson ToEntity(this Expense entity)
    {
        return new FullExpenseResponseJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description ?? "",
            Amount = entity.Amount.ToString("C", new CultureInfo("pt-BR")),
            Date = entity.Date.ToString("dd/MM/yyyy"),
            Type = entity.ExpenseType.ToString()
        };
    }

    public static List<FullExpenseResponseJson> ToResponse(this List<Expense> entities)
    {
        return [.. entities.Select(e => e.ToEntity())];
    }

    public static ListExpensesCriteria ToListExpenseCriteria(this ListPageExpensesRequestJson request)
    {
        return new ListExpensesCriteria
        {
            Title = request.Title,
            DateRange = (request.InitialDate.HasValue && request.FinalDate.HasValue)
                ? new DateRange(request.InitialDate.Value, request.FinalDate.Value)
                : null,
            Pagination = new Pagination(request.Number, request.Size)
        };
    }
}
