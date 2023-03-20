using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarRental: BaseAuditableEntity
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public int CarInventoryId { get; set; }

        public CarInventory CarInventory { get; set; } = null!;

        public DateOnly RequestDate { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.PENDING;

        public bool IsCancelled { get; set; }

        public bool IsReturned { get; set; }

        public virtual CarDamage? CarDamage { get; set; }
    }
}
