using Carental.Domain.Common;

namespace Carental.Domain.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity: BaseEntity, new()
    {
        public IQueryable<TEntity> Query(bool noTracking = true);
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
