using Carental.Domain.Common;
using Carental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carental.Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        public string? ImageId { get; set; }
        public virtual File? Image { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string Address { get; set; } = null!;
        public string? DocumentId { get; set; }
        public virtual File? Document { get; set; }
        public DocumentType? DocumentType { get; set; }

        public virtual ICollection<CarRental> CarRentals { get; set; } = null!;
    }
}
