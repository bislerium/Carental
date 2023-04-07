using Carental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carental.Infrastructure.Persistence.Configurations
{
    internal class DiscountOfferConfiguration : IEntityTypeConfiguration<DiscountOffer>
    {
        public void Configure(EntityTypeBuilder<DiscountOffer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
