using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Persistence.Rental
{
    public record CarRentalsResponseDTO( 
        string CarId,
        string Name,
        decimal RentalRate,

        DateOnly RequestDate,
        ApprovalStatus ApprovalStatus,
        DateTime ApprovedOn,
        bool IsCancelled,
        bool IsReturned,
        DateTime ReturnOrCancelDateTime,
        decimal RentPrice,

        string? DiscountOfferId,
        string? VoucherCode,
        int DiscountRate,

        string? CarDamageId,

        string CustomerId,
        UserRole UserRole);
}