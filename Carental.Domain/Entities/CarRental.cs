using Carental.Domain.Common;
using Carental.Domain.Enums;

namespace Carental.Domain.Entities
{
    public class CarRental: BaseAuditableEntity
    {
        public string CustomerId { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public string CarInventoryId { get; set; } = null!;

        public virtual CarInventory CarInventory { get; set; } = null!;

        public DateOnly RequestDate { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.PENDING;

        public bool IsCancelled { get; set; }

        public bool IsReturned { get; set; }

        public DateTime ReturnOrCancelDateTime { get; set; }

        public string? DiscountOfferId { get; set; }

        public virtual DiscountOffer? DiscountOffer { get; set; }

        public decimal RentPrice { get; set; }

        public virtual CarDamage? CarDamage { get; set; }
    }
}
