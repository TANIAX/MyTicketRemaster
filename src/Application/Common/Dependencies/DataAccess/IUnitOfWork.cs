using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Application.Common.Dependencies.DataAccess;

public interface IUnitOfWork : IDisposable
{
    bool HasActiveTransaction { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    public Task SaveChanges();
}
