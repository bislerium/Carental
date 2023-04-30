using Carental.Domain.Common;
using Carental.Domain.Enums;

namespace Carental.Domain.Entities
{
    public class Car: BaseAuditableEntity
    {
        public string? ImageId { get; set; }
        public virtual File? Image { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateOnly Year { get; set; }
        public string Color { get; set; } = null!;
        public int Seats { get; set; }
        public CarType CarType { get; set; }
        public FuelType FuelType { get; set; }

        public virtual CarInventory CarInventory { get; set; } = null!;
    }
}
