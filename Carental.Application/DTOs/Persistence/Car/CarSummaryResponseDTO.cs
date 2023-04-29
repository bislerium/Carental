using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Persistence.Car
{
    public class CarSummaryResponseDTO
    {
        public string Id { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public decimal RentalRate { get; set; }
        public bool IsRented { get; set; }
    }
}
