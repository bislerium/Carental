using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Identity;
using Carental.Application.Exceptions.CRUD;
using Carental.Infrastructure.Identity.Entities;
using Carental.Infrastructure.Identity.Extensions;
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

        public async Task<string> CreateAccount(CreateAccountRequest createAccountRequest)
        {
            AppUser user = new()
            {
                UserName = createAccountRequest.UserName,
                Email = createAccountRequest.Email,
                PhoneNumber = createAccountRequest.PhoneNumber
            };

            IdentityResult createAccountResult = await _userManager.CreateAsync(user, createAccountRequest.Password);

            if (!createAccountResult.Succeeded)
            {
                createAccountResult.Errors.ToErrorDictionary(out Dictionary<string, string[]> errors);
                throw new CreateFailedException<AppUser>(errors);
            }

            IdentityResult createRoleResult = await _userManager.AddToRoleAsync(user, createAccountRequest.Role.ToString());

            if (!createRoleResult.Succeeded)
            {
                createRoleResult.Errors.ToErrorDictionary(out Dictionary<string, string[]> errors);
                throw new CreateFailedException<AppUser>(errors);
            }

            return user.Id;
        }

    }
}
