using Domain.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class AppRepositories : IRepositories
    {
        private protected readonly AppDBContext _dbContext;

        private ICarRepository? _carRepository;
        private ICarInventoryRepository? _carInventoryRepository;
        private ICarRentalRepository? _carRentalRepository;
        private ICarDamageRepository? _carDamageRepository;
        private IDiscountOfferRepository? _discountOfferRepository;
        private ICustomerRepository? _customerRepository;

        public AppRepositories(AppDBContext dbContext)
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

        public ICarInventoryRepository CarInventoryRepository
        {
            get
            {
                return _carInventoryRepository ??= new CarInventoryRepository(_dbContext);
            }
        }

        public ICarRentalRepository CarRentalRepository
        {
            get
            {
                return _carRentalRepository ??= new CarRentalRepository(_dbContext);
            }
        }

        public ICarDamageRepository CarDamageRepository
        {
            get
            {
                return _carDamageRepository ??= new CarDamageRepository(_dbContext);
            }
        }

        public IDiscountOfferRepository DiscountOfferRepository
        {
            get
            {
                return _discountOfferRepository ??= new DiscountOfferRepository(_dbContext);
            }
        }
    }
}
