using Carental.Domain.Entities;
using Carental.Domain.Repositories;
using Carental.Infrastructure.Persistence.Contexts;
using Carental.Infrastructure.Persistence.Repositories.Base;

namespace Carental.Infrastructure.Persistence.Repositories
{
    public class CarDamageRepository : Repostiory<CarDamage>, ICarDamageRepository
    {
        public CarDamageRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
