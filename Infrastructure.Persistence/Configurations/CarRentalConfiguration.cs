using Domain.Entities;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    internal class CarRentalConfiguration : IEntityTypeConfiguration<CarRental>
    {
        public void Configure(EntityTypeBuilder<CarRental> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(r => r.CarInventory)
                .WithMany(i => i.Rentals)
                .HasForeignKey(x => x.CarInventoryId);

            builder
                .HasOne(r => r.Customer)
                .WithMany(c => c.CarRentals)
                .HasForeignKey(r => r.CustomerId);

            builder.Property(x => x.RequestDate)
                .IsRequired()
                .HasConversion<DateOnlyToDateTimeConverter>();
        }
    }
}
