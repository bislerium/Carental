using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Identity
{
    internal static class Registration
    {
        internal static void AddIdentity(this IServiceCollection services) {

           services.AddIdentity<AppUser, IdentityRole>(options =>
          {
              options.User.RequireUniqueEmail = true;

              options.Password.RequiredLength = 6;
              options.Password.RequireDigit = true;
              options.Password.RequireLowercase = true;
              options.Password.RequireNonAlphanumeric = true;
              options.Password.RequireUppercase = true;

              // options.SignIn.RequireConfirmedEmail = true;

              options.Lockout.MaxFailedAccessAttempts = 5;
              options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
          })
          .AddEntityFrameworkStores<AppDBContext>()
          .AddDefaultTokenProviders();
        }
      
    }
}
