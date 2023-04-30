using Carental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

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

            builder
                .HasOne(c => c.Image)
                .WithOne()
                .HasForeignKey<Customer>(c => c.ImageId);

            builder
                .HasOne(c => c.Document)
                .WithOne()
                .HasForeignKey<Customer>( c => c.DocumentId);                
        }
    }
}
