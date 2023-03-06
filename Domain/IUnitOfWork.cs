using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Base;

namespace Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository CarRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
