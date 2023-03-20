using Domain.Repositories;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork : IRepositories, IDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
