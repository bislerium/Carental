using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CarRentalRepository : Repostiory<CarRental>, ICarRentalRepository
    {
        public CarRentalRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
