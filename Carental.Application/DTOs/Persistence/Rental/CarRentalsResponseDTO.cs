using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Persistence.Rental
{
    public record CarRentalsResponseDTO( string CarId, string CarName, decimal RentalRate, DateOnly RequestDate, ApprovalStatus ApprovalStatus, bool IsCancelled, bool IsReturned, string CarDamageId, string CustomerId, UserRole UserRole, string UserName);
}