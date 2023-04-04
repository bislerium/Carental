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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(r => r.CarInventory)               
                .WithMany(i => i.Rentals)
                .HasForeignKey(x => x.CarInventoryId);

            builder.Property(x => x.RequestDate)
                .IsRequired()
                .HasConversion<DateOnlyToDateTimeConverter>();
        }
    }
}
