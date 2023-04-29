using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Persistence.Car
{
    public record CreateCarRequestDTO (string Make, string Model, DateOnly Year, string Color, int Seats, CarType CarType, FuelType FuelType, decimal RentalRate);
}
