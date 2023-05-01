using Carental.Domain.Entities;
using Carental.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carental.Infrastructure.Persistence.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(c => c.Image)
                .WithOne()
                .HasForeignKey<Car>(c => c.ImageId);

            builder.Property(x => x.Make)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Year)
                .IsRequired()
                .HasConversion<DateOnlyToDateTimeConverter>();

            builder.Property(x => x.Color);

            builder.Property(x => x.Seats);

            builder.Property(x => x.CarType);

            builder.Property(x => x.FuelType);
        }
    }
}
