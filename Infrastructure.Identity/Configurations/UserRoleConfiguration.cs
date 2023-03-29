using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            IdentityUserRole<string> userRole = new()
            {
                UserId = "0de77141-d6ea-4245-a54b-559493e97c37",
                RoleId = "e65a3dfc-8509-4552-a814-ccd9df889670"
            };

            builder.HasData(userRole);
        }
    }
}
