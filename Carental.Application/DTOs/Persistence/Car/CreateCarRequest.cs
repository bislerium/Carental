using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Persistence.Car
{
    public record CreateCarRequest (string Make, string Model, DateOnly Year, string Color, int Seats, CarType CarType, FuelType FuelType);
}
