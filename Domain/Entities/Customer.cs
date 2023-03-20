using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {   
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<CarRental> CarRentals { get; set; } = null!;
    }
}
