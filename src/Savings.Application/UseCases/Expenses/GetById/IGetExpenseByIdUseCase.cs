using Savings.Application.Abstractions;
using Savings.Comunication.Responses;

namespace Savings.Application.UseCases.Expenses.GetById;

public interface IGetExpenseByIdUseCase : IUseCase<long, FullExpenseResponseJson> { }
