using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarDamage: AuditableEntity
    {
        public int RentalID { get; set; }

        public Rental Rental { get; set; } = null!;

        public string DamageDescription { get; set; } = null!;

        public DateTime ReportedOn { get; set; }

        public ReviewStatus ReviewStatus { get; set; }

        public DateTime ReviewedOn { get; set; }

        public bool IsChargePaid { get; set; }

        public DateTime PaidOn { get; set; }

    }
}
