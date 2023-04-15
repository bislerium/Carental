using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Persistence.Car
{
    public class CarDetailResponse
    {
        public string Id { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateOnly Year { get; set; }
        public string Color { get; set; } = null!;
        public int Seats { get; set; }
        public CarType CarType { get; set; }
        public FuelType FuelType { get; set; }
        public int RentalRate { get; set; }
        public bool IsRented { get; set; }
    }
}
