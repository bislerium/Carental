using Carental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carental.Infrastructure.Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(c => c.CarRentals)
                .WithOne(r => r.Customer)                
                .HasForeignKey(r => r.CustomerId);
        }
    }
}
