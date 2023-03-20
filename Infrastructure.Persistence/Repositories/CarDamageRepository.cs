using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories.Base;

namespace Infrastructure.Persistence.Repositories
{
    public class CarDamageRepository : Repostiory<CarDamage>, ICarDamageRepository
    {
        public CarDamageRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
