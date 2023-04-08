using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Identity;
using Carental.Application.Enums;
using Carental.Application.Exceptions;
using Carental.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Carental.Infrastructure.Identity.Services
{
    internal class AuthSignInManager : ISignInManager
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthSignInManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<AuthSignInResult> SignInAsync(SignInRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new NotFoundException();
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RemeberMe, true);

            return Enum.Parse<AuthSignInResult>(result.ToString(), ignoreCase: true);
        }

        public async Task SignOutAsync(CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
        }
    }
}
