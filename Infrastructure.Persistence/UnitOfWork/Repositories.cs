using Domain.Repositories;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.UnitOfWork
{
    public abstract class Repositories
    {
        protected internal readonly AppDBContext _dbContext;

        private ICarRepository? _carRepository;
        private ICustomerRepository? _customerRepository;

        internal Repositories(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICarRepository CarRepository
        {
            get
            {
                return _carRepository ??= new CarRepository(_dbContext);
            }
        }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ??= new CustomerRepository(_dbContext);
            }
        }
    }
}
