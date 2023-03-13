using Domain.Common;

namespace Domain.Entities
{
    public class DiscountOffer: AuditableEntity
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int DiscountRate { get; set; }

        public DateTime StartDate { get; set;  }

        public DateTime EndDate { get; set; }
    }
}
