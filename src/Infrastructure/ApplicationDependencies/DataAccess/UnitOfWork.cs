using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;
using MyTicketRemaster.Infrastructure.Persistence.Context;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction? _currentTransaction;

    public IGroupRepository Groups { get; } = null!;
    public IProjectRepository Projects { get; } = null!;
    public IStatusRepository Status { get; } = null!;
    public ITypeRepository Types { get; } = null!;
    public IPriorityRepository Priorities { get; } = null!;
    public IStoredReplyRepository StoredReplies { get; } = null!;
    public IEmployeeRepository Employees { get; set; } = null!;
    public UnitOfWork(ApplicationDbContext dbContext, IGroupRepository groups, 
        IProjectRepository projects,
        IStatusRepository status,
        ITypeRepository types,
        IPriorityRepository priorities,
        IStoredReplyRepository storedReplies,
        IEmployeeRepository employees) 
    {
        _dbContext = dbContext;
        Groups = groups;
        Projects = projects;
        Status = status;
        Types = types;
        Priorities = priorities;
        StoredReplies = storedReplies;
        Employees = employees;
    }

    public void Dispose()
        => _dbContext.Dispose();

    /// <summary>
    /// Saves all changes to tracked entities.
    /// If an explicit transaction has not yet been started, the
    /// save operation itself is executed in a new transaction.
    /// </summary>
    public Task SaveChanges()
        => _dbContext.SaveChangesAsync();

    public bool HasActiveTransaction
        => _currentTransaction is not null;

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction is not null)
        {
            throw new InvalidOperationException("A transaction is already in progress.");
        }

        _currentTransaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.RepeatableRead);
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();

            _currentTransaction?.Commit();
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_currentTransaction is not null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_currentTransaction is null)
        {
            throw new InvalidOperationException("A transaction must be in progress to execute rollback.");
        }

        try
        {
            await _currentTransaction.RollbackAsync();
        }
        finally
        {
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }
    }
}
