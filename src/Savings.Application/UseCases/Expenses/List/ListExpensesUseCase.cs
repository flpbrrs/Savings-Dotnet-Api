using Savings.Application.Mappers;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Domain.Repositories.Expenses;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.List;

public class ListExpensesUseCase(IExpensesRepository _expensesRepository) : IListExpensesUseCase
{
    public async Task<PageResult<ListPageExpensesResponseJson>> Execute(ListPageExpensesRequestJson filters)
    {
        var filtersAreValid = new ListExpensesValidator().Validate(filters);

        if (!filtersAreValid.IsValid)
            throw new ValidationException([.. filtersAreValid.Errors.Select(x => x.ErrorMessage)]);

        var pageNumber = filters.Number < 1 ? 1 : filters.Number;
        var pageSize = filters.Size < 1 ? 10 : filters.Size;

        var (filteredExpenses, totalCount) = await _expensesRepository.List(
            page: pageNumber,
            pageSize: pageSize,
            initialDate: filters.InitialDate,
            finalDate: filters.FinalDate,
            title: filters.Title
        );

        return new PageResult<ListPageExpensesResponseJson>
        {
            Items = filteredExpenses.ToResponseList(),
            TotalCount = totalCount,
            CurrentPage = pageNumber,
            PageSize = pageSize
        };
    }
}
