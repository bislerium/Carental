using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carental.Infrastructure.Persistence.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.Entities.File>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Ignore(e => e.Name);
            builder.Ignore(e => e.FullName);
            builder.Ignore(e => e.Extension);
        }
    }
}
