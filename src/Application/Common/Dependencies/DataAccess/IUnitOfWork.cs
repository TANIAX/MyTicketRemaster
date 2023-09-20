using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Application.Common.Dependencies.DataAccess;

public interface IUnitOfWork : IDisposable
{
    bool HasActiveTransaction { get; }

    public IGroupRepository Groups { get; }
    public IProjectRepository Projects { get; }
    public IStatusRepository Status { get; }
    public ITypeRepository Types { get; }
    public IPriorityRepository Priorities { get; }
    public IStoredReplyRepository StoredReplies { get; }
    public IEmployeeRepository Employees { get; }
    public IContactRepository Contacts { get; }
    public ICustomerRepository Customers { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    public Task SaveChanges();
}
