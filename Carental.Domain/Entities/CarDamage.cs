using Carental.Domain.Common;
using Carental.Domain.Enums;

namespace Carental.Domain.Entities
{
    public class CarDamage: BaseAuditableEntity
    {
        public CarRental Rental { get; set; } = null!;

        public string DamageDescription { get; set; } = null!;

        public DateTime ReportedOn { get; set; }

        public ReviewStatus ReviewStatus { get; set; }

        public DateTime ReviewedOn { get; set; }

        public int Charge { get; set; }

        public bool IsChargePaid { get; set; }

        public DateTime PaidOn { get; set; }

        public PaymentType PaymentType { get; set; }        
    }
}
