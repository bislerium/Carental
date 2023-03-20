using Domain.Common;
using Domain.Repositories.Base;

namespace Infrastructure.Persistence.Repositories.Base
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
    }
}
