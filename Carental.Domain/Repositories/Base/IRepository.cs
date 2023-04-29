using Carental.Domain.Common;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Carental.Domain.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity: BaseEntity, new()
    {
        public IQueryable<TEntity> Query(bool noTracking = true);
        public Task<TEntity?> FindByIdAsync(string key, CancellationToken cancellationToken = default);
        public IAsyncEnumerable<TEntity> SortAsync(Expression<Func<TEntity, bool>>? predicate, IReadOnlyDictionary<Expression<Func<TEntity, object>>, bool>? orderBy, CancellationToken cancellationToken = default);
        public IAsyncEnumerable<TEntity> GetAllAsync(CancellationToken cancellationToken = default);
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Update<TKey>(string id, Expression<Func<TEntity, TKey>> property, TKey value);
        public Task Update<TKey>(string id, Expression<Func<TEntity, TKey>> property, TKey value, CancellationToken cancellationToken = default);
        public void Update<TKey>(string id, IDictionary<Expression<Func<TEntity, TKey>>, TKey> propertyValuePairs);
        public Task Update<TKey>(string id, IDictionary<Expression<Func<TEntity, TKey>>, TKey> propertyValuePairs, CancellationToken cancellationToken = default);
        public void Delete(TEntity entity);
    }
}