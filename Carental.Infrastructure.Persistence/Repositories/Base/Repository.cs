using Carental.Application.Exceptions;
using Carental.Domain.Common;
using Carental.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Carental.Infrastructure.Persistence.Repositories.Base
{
    public class Repostiory<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDBContext _dbContext;

        public Repostiory(AppDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<TEntity> Query(bool noTracking = true)
        {
            DbSet<TEntity> entitySet = _dbContext.Set<TEntity>();
            return noTracking
                ? entitySet.AsNoTracking()
                : entitySet.AsTracking();
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update<TKey>(string id, Expression<Func<TEntity, TKey>> property, TKey value)
        {
            TEntity entity = CreateAndGetEntity(id);

            UpdatePropertyValue(entity, property, value);
        }

        public async Task Update<TKey>(string id, Expression<Func<TEntity, TKey>> property, TKey value, CancellationToken cancellationToken = default)
        {
            TEntity entity = await FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException();

            UpdatePropertyValue(entity, property, value);
        }

        public void Update<TKey>(string id, IDictionary<Expression<Func<TEntity, TKey>>, TKey> propertyValuePairs)
        {
            TEntity entity = CreateAndGetEntity(id);

            foreach (var pair in propertyValuePairs)
            {
                UpdatePropertyValue(entity, pair.Key, pair.Value);
            }
        }

        public async Task Update<TKey>(string id, IDictionary<Expression<Func<TEntity, TKey>>, TKey> propertyValuePairs, CancellationToken cancellationToken = default)
        {
            TEntity entity = await FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException();

            foreach (var pair in propertyValuePairs)
            {
                UpdatePropertyValue(entity, pair.Key, pair.Value);
            }
        }
       
        private TEntity CreateAndGetEntity(string id) 
        {
            
            TEntity entity = Activator.CreateInstance<TEntity>();
            entity.Id = id;
            _dbContext.Attach(entity);
            
            return entity;
        }

        private void UpdatePropertyValue<TKey>(TEntity entity,Expression<Func<TEntity, TKey>> property, TKey value)
        {
            string propertyName = ((MemberExpression)property.Body).Member.Name;
            PropertyEntry entry = _dbContext.Entry(entity).Property(propertyName);
            entry.CurrentValue = value;
            entry.IsModified = true;
        }

        public async Task<TEntity?> FindByIdAsync(string key, CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Set<TEntity>()
                .FindAsync(new object?[] { key }, cancellationToken: cancellationToken);
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, CancellationToken cancellationToken = default)
        {
            return await Query(noTracking)
                .FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async IAsyncEnumerable<TEntity> GetAllAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var batchSize = 100; //Fetch number of rows per database round trip. smaller batch size = number of records/rows improves memory usuage.
            var skip = 0; // offset

            while (true)
            {
                var entities = await _dbContext.Set<TEntity>()
                    .OrderBy(e => e.Id)
                    .Skip(skip)
                    .Take(batchSize)
                    .ToListAsync(cancellationToken);
                    

                if (entities.Count == 0)
                {
                    yield break;
                }

                foreach (var entity in entities)
                {
                    yield return entity;
                }

                skip += batchSize;
            }
        }

        public async IAsyncEnumerable<TEntity> SortAsync(Expression<Func<TEntity, bool>>? predicate, IReadOnlyDictionary<Expression<Func<TEntity, object>>, bool>? orderBy, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> collections = _dbContext.Set<TEntity>().AsNoTracking();

            if (predicate is not null) 
            {
                collections = collections.Where(predicate);
            }

            if (orderBy is not null && orderBy.Count > 0)
            {
                var pair = orderBy.First();
                var orderedCollection = pair.Value
                    ? collections.OrderBy(pair.Key)
                    : collections.OrderByDescending(pair.Key);

                for (int i = 1; i < orderBy.Count; i++)
                {
                    pair = orderBy.ElementAt(i);
                    orderedCollection = pair.Value
                        ? orderedCollection.ThenBy(pair.Key)
                        : orderedCollection.ThenByDescending(pair.Key);
                }

                await foreach (var entity in orderedCollection.AsAsyncEnumerable().WithCancellation(cancellationToken))
                {
                    yield return entity;
                }
            }
            else
            {
                await foreach (var entity in collections.AsAsyncEnumerable().WithCancellation(cancellationToken))
                {
                    yield return entity;
                }
            }
        }
    }
}
