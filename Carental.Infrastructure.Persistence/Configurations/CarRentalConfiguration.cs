using Carental.Domain.Entities;
using Carental.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carental.Infrastructure.Persistence.Configurations
{
    internal class CarRentalConfiguration : IEntityTypeConfiguration<CarRental>
    {
        public void Configure(EntityTypeBuilder<CarRental> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.RentPrice)
                .IsRequired()
                .HasPrecision(9, 2);

            builder
                .HasOne(r => r.CarInventory)               
                .WithMany(i => i.Rentals)
                .HasForeignKey(r => r.CarInventoryId);

            builder.Property(r => r.RequestDate)
                .IsRequired()
                .HasConversion<DateOnlyToDateTimeConverter>();
        }
    }
}
