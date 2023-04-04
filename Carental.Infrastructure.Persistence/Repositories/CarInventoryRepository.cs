using Carental.Domain.Entities;
using Carental.Domain.Repositories;
using Carental.Infrastructure.Persistence.Contexts;
using Carental.Infrastructure.Persistence.Repositories.Base;

namespace Carental.Infrastructure.Persistence.Repositories
{
    public class CarInventoryRepository : Repostiory<CarInventory>, ICarInventoryRepository
    {
        public CarInventoryRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
