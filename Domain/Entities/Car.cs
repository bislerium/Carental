using Domain.Common;

namespace Domain.Entities
{
    public class Car: AuditableEntity
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
