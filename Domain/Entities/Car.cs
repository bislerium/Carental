using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Car: BaseAuditableEntity
    {
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateOnly Year { get; set; }
        public string Color { get; set; } = null!;
        public int Seats { get; set; }
        public CarType CarType { get; set; }
        public FuelType FuelType { get; set; }

        public CarInventory CarInventory { get; set; } = null!;
    }
}
