using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class CarRepository : Repostiory<Car>, ICarRepository
    {
        public CarRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
