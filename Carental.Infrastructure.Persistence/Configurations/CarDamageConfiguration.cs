using Carental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carental.Infrastructure.Persistence.Configurations
{
    internal class CarDamageConfiguration : IEntityTypeConfiguration<CarDamage>
    {
        public void Configure(EntityTypeBuilder<CarDamage> builder)
        {
           builder.HasKey(d => d.Id);

            builder.Property(d=> d.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(d => d.Rental)
                .WithOne(r => r.CarDamage)
                .HasForeignKey<CarDamage>(d => d.Id);

        }
    }
}
