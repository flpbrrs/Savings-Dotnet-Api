using Savings.Comunication.Responses;
using Savings.Domain.Entities;
using System.Globalization;

namespace Savings.Application.Mappers;

public static class ExpensesListMapProfile
{
    private static ListPageExpensesResponseJson ToListResponse(this Expense entity)
    {
        return new ListPageExpensesResponseJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description ?? "",
            Amount = entity.Amount.ToString("C", new CultureInfo("pt-BR")),
            Date = entity.Date.ToString("dd/MM/yyyy"),
            Type = entity.ExpenseType.ToString()
        };
    }

    public static List<ListPageExpensesResponseJson> ToResponseList(this List<Expense> entities)
    {
        return [.. entities.Select(e => e.ToListResponse())];
    }
}

