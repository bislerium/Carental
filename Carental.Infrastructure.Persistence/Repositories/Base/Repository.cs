using Carental.Domain.Common;
using Carental.Domain.Repositories.Base;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Carental.Infrastructure.Persistence.Repositories.Base
{
    public class Repostiory<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDBContext dbContext;

        public Repostiory(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TEntity> Query(bool noTracking = true)
        {
            DbSet<TEntity> entitySet = dbContext.Set<TEntity>();
            return noTracking
                ? entitySet.AsNoTracking()
                : entitySet.AsTracking();
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }


        public async Task<TEntity?> FindByIdAsync(string key, CancellationToken cancellationToken)
        {
            return await dbContext
                .Set<TEntity>()
                .FindAsync(new object?[] { key }, cancellationToken: cancellationToken);
        }

        public async IAsyncEnumerable<TEntity> GetAllAsync([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var batchSize = 100; //Fetch number of rows per database round trip. smaller batch size = number of records/rows improves memory usuage.
            var skip = 0; // offset

            while (true)
            {
                var entities = await dbContext.Set<TEntity>()
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

        public async IAsyncEnumerable<TEntity> FilterAsync(Expression<Func<TEntity, bool>>? predicate, IReadOnlyDictionary<Expression<Func<TEntity, object>>, bool>? orderBy, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            IQueryable<TEntity> collections = dbContext.Set<TEntity>().AsNoTracking();

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
