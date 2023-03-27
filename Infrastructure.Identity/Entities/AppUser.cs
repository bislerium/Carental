using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public User User { get; set; } = null!;
    }
}
