using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Savings.Domain.Repositories;
using Savings.Domain.Repositories.Expenses;
using Savings.Infrastructure.Database;
using Savings.Infrastructure.Database.Repositories;

namespace Savings.Infrastructure;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SavingsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IReadOnlyExpensesRepository, ExpensesRepository>();
        services.AddScoped<IWriteOnlyExpensesRepository, ExpensesRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
