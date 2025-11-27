using Microsoft.Extensions.DependencyInjection;
using Savings.Application.UseCases.Expenses.Delete;
using Savings.Application.UseCases.Expenses.GetById;
using Savings.Application.UseCases.Expenses.List;
using Savings.Application.UseCases.Expenses.Register;

namespace Savings.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IListExpensesUseCase, ListExpensesUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();

        return services;
    }
}
