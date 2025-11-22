using Savings.Application.Abstractions;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;

namespace Savings.Application.UseCases.Expenses.List;

public interface IListExpensesUseCase : IUseCase<ListPageExpensesRequestJson, PageResult<FullExpenseResponseJson>> { }
