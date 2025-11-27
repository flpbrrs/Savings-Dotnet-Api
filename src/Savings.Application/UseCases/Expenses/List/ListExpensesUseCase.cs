using Savings.Application.Mappers;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;
using Savings.Domain.Repositories.Expenses;
using Savings.Exceptions;

namespace Savings.Application.UseCases.Expenses.List;

public class ListExpensesUseCase(IReadOnlyExpensesRepository _expensesRepository) : IListExpensesUseCase
{
    public async Task<PageResult<FullExpenseResponseJson>> Execute(ListPageExpensesRequestJson filters)
    {
        // TODO: Adicionar o userId para receber apenas as expenses do usuário autenticado

        var filtersAreValid = new ListExpensesValidator().Validate(filters);

        if (!filtersAreValid.IsValid)
            throw new ValidationException([.. filtersAreValid.Errors.Select(x => x.ErrorMessage)]);

        var criteria = filters.ToListExpenseCriteria();

        var (filteredExpenses, totalCount) = await _expensesRepository.List(criteria);

        return new PageResult<FullExpenseResponseJson>
        {
            Items = filteredExpenses.ToFullResponseList(),
            TotalCount = totalCount,
            CurrentPage = criteria.Pagination.Page,
            PageSize = criteria.Pagination.PageSize
        };
    }
}
