using Carental.Domain.Common;
using Carental.Domain.Repositories.Base;
using Carental.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace Carental.Infrastructure.Persistence.Repositories.Base
{
    public class Repostiory<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDBContext _dbContext;

        public Repostiory(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Query(bool noTracking = true)
        {
            DbSet<TEntity> entitySet = _dbContext.Set<TEntity>();
            return noTracking
                ? entitySet.AsNoTracking().AsQueryable()
                : entitySet.AsQueryable();
        }

        public void Add(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
        }
        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<TEntity?> FindByIdAsync(string key)
        {
            return await _dbContext
                .Set<TEntity>()
                .FindAsync(key);
        }



        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext
                .Set<TEntity>()
                .ToListAsync();
        }

        public Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>>? predicate, IDictionary<Expression<Func<TEntity, object>>, bool> orderBy)
        {
            IQueryable<TEntity> collections = _dbContext.Set<TEntity>().AsNoTracking();

            if (predicate != null) 
            {
                collections = collections.Where(predicate);
            }

            IOrderedQueryable<TEntity> orderedCollection = null!;

            // Order the collection by the first property
            if (orderBy.Count > 0)
            {
                var pair = orderBy.ElementAt(0);
                orderedCollection = pair.Value 
                    ? collections.OrderBy(pair.Key)
                    : collections.OrderByDescending(pair.Key);
            }

            // Then order the collection by any additional properties
            for (int i = 1; i < orderBy.Keys.Count; i++)
            {
                var pair = orderBy.ElementAt(i);
                orderedCollection = pair.Value
                    ? orderedCollection.ThenBy(pair.Key)
                    : orderedCollection.ThenByDescending(pair.Key);
            }

            foreach (TEntity e in orderedCollection) 
            {
                yield return e;
            }
        }
    }
}
