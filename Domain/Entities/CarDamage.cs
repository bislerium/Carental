using Domain.Common;
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

        public DateTime DamageReportTime { get; set; }

        public bool IsInspected { get; set; }

        public bool IsCharegeable { get; set; }

        public bool IsChargePaid { get; set; }

        public DateTime PaidOn { get; set; }

    }
}
