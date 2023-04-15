using Carental.Domain.Common;

namespace Carental.Domain.Entities
{
    public class CarInventory : BaseAuditableEntity
    {
        public virtual Car Car { get; set; } = null!;
        public decimal RentalRate { get; set; } 
        public bool IsRented { get; set; }
        public virtual ICollection<CarRental> Rentals { get; set; } = null!;
    }
}
