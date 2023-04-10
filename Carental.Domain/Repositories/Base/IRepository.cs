using Carental.Domain.Common;
using System.Linq.Expressions;

namespace Carental.Domain.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity: BaseEntity, new()
    {
        public IQueryable<TEntity> Query(bool noTracking = true);
        public Task<TEntity?> FindByIdAsync(string key);
        public Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>>? predicate, IDictionary<Expression<Func<TEntity, object>>, bool> orderBy);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}