using Carental.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carental.Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        public User User { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<CarRental> CarRentals { get; set; } = null!;
    }
}
