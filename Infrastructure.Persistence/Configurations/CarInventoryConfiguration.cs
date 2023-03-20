using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class CarInventoryConfiguration : IEntityTypeConfiguration<CarInventory>
    {
        public void Configure(EntityTypeBuilder<CarInventory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(c => c.Car)
                .WithOne(i => i.CarInventory)
                .HasForeignKey<CarInventory>(i => i.Id);
        }
    }
}
