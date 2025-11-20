namespace Savings.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
}
