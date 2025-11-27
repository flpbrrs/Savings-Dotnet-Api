using Savings.Application.Abstractions;
using Savings.Comunication.Requests;
using Savings.Comunication.Responses;

namespace Savings.Application.UseCases.Expenses.Register;

public interface IRegisterExpenseUseCase : IUseCase<ExpenseRequestJson, RegisterExpenseResponseJson> { }
