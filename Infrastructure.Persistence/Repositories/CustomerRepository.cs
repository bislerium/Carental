using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : Repostiory<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
    }
}
