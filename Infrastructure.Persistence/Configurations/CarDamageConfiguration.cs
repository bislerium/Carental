using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class CarDamageConfiguration : IEntityTypeConfiguration<CarDamage>
    {
        public void Configure(EntityTypeBuilder<CarDamage> builder)
        {
           builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(d => d.Rental)
                .WithOne(r => r.CarDamage)
                .HasForeignKey<CarDamage>(d => d.Id);

        }
    }
}
