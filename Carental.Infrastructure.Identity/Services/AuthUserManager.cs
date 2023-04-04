using Carental.Application.Contracts.Identity;
using Carental.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Carental.Infrastructure.Identity.Services
{
    internal class AuthUserManager : IUserManager
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AuthUserManager(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


    }
}
