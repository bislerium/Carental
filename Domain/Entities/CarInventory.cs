using Domain.Common;

namespace Domain.Entities
{
    public class CarInventory : BaseAuditableEntity
    {
        public Car Car { get; set; } = null!;

        public int RentalRate { get; set; } 
        public bool IsRented { get; set; }

        public ICollection<CarRental> Rentals { get; set; } = null!;
    }
}
