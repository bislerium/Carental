using Carental.Domain.Common;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Carental.Domain.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity: BaseEntity, new()
    {
        public IQueryable<TEntity> Query(bool noTracking = true);
        public Task<TEntity?> FindByIdAsync(string key, CancellationToken = default);
        public IAsyncEnumerable<TEntity> FilterAsync(Expression<Func<TEntity, bool>>? predicate, IReadOnlyDictionary<Expression<Func<TEntity, object>>, bool>? orderBy, CancellationToken cancellationToken = default);
        public IAsyncEnumerable<TEntity> GetAllAsync(CancellationToken cancellationToken = default);
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}