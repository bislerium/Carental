using Domain.Common;

namespace Domain.Entities
{
    public class Inventory: AuditableEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public int RentalRate { get; set; } 
        public bool IsRented { get; set; }


    }
}
