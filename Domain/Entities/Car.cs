using Domain.Common;

namespace Domain.Entities
{
    public class Car: AuditableEntity
    {
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateOnly Year { get; set; }
        public string Color { get; set; } = null!;
        public string LicensePlate { get; set; } = null!;
        public int RentalRate { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsRented { get; set; }
    }
}
