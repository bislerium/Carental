using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories.Base;

namespace Infrastructure.Persistence.Repositories
{
    public class CarInventoryRepository : Repostiory<CarInventory>, ICarInventoryRepository
    {
        public CarInventoryRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
