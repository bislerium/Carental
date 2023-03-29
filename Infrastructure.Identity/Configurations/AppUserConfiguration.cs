using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Identity.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        private readonly string _IntitialUserName = "admin";
        private readonly string _IntitialUserPassword = "admin";

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);

            PasswordHasher<AppUser> passwordHasher = new();

            AppUser user = new()
            {
                Id = "0de77141-d6ea-4245-a54b-559493e97c37",
                UserName = _IntitialUserName,
                NormalizedUserName = _IntitialUserName.ToUpper(),
                
                PasswordHash = passwordHasher.HashPassword(null!, _IntitialUserPassword),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),                
            };

            builder.HasData(user);
        }
    }
}
