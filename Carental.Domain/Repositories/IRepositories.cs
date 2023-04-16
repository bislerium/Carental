namespace Carental.Domain.Repositories
{
    public interface IRepositories
    {
        public ICarRepository CarRepository { get; }
        public ICarInventoryRepository CarInventoryRepository { get; }
        public ICarRentalRepository CarRentalRepository { get; }
        public ICarDamageRepository CarDamageRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IDiscountOfferRepository DiscountOfferRepository { get; }
        public IFileRepository FileRepository { get; }
    }
}
