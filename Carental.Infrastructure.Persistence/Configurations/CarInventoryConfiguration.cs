﻿using Carental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carental.Infrastructure.Persistence.Configurations
{
    internal class CarInventoryConfiguration : IEntityTypeConfiguration<CarInventory>
    {
        public void Configure(EntityTypeBuilder<CarInventory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.RentalRate)
                .IsRequired()
                .HasPrecision(6, 2);

            builder
                .HasOne(c => c.Car)
                .WithOne(i => i.CarInventory)
                .HasForeignKey<CarInventory>(i => i.Id);
        }
    }
}
