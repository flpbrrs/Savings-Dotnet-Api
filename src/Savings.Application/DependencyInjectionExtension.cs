using Microsoft.Extensions.DependencyInjection;
using Savings.Application.UseCases.Expenses.Register;

namespace Savings.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();

        return services;
    }
}
