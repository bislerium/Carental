using Carental.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carental.Infrastructure.Identity.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasKey(x => x.Id);

            int count = 0;

            List<IdentityRole> roles = Enum
                .GetNames<UserRole>()
                .Select(roleName => 
                {
                    return new IdentityRole()
                    {
                        Id = "e65a3dfc-8509-4552-a814-ccd9df88967" + count++,
                        Name = roleName,
                        NormalizedName = roleName.ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    };
                }).ToList();

            builder.HasData(roles);
        }
    }
}
