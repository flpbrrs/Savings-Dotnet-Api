using Savings.Domain.Repositories;

namespace Savings.Infrastructure.Database;

internal class UnitOfWork(SavingsDbContext _dbContext) : IUnitOfWork
{
    public async Task Commit() => await _dbContext.SaveChangesAsync();

    public void Dispose()
    {
        _dbContext?.Dispose();
        GC.SuppressFinalize(this);
    }
}
