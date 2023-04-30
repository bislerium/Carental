using Carental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Carental.Infrastructure.Persistence.Configurations
{
    internal class DiscountOfferConfiguration : IEntityTypeConfiguration<DiscountOffer>
    {
        public void Configure(EntityTypeBuilder<DiscountOffer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(v => v.Code)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasAnnotation(nameof(RegularExpressionAttribute), "^CR[A-Z0-9]{6}$");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.DiscountRate).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
        }
    }
}
