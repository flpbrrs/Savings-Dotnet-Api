using Savings.Application.Abstractions;
using Savings.Comunication.Requests;

namespace Savings.Application.UseCases.Expenses.Update;

public interface IUpdateExpenseUseCase : IUseCase<UpdateExpenseRequestFilterJson, Empty> { }
