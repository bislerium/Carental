using Application.Contracts.Identity;
using Application.DTOs.Identity;
using Application.Exceptions;
using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Managers
{
    internal class SignInManager: ISignInManager
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public SignInManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async void SignIn(SignInRequest request) {
            AppUser? user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null) {
                throw new NotFoundException();
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RemeberMe,  request.LockOutOnFailure);
        }

        public async void SignOut() { 
            await _signInManager.SignOutAsync();
        }
    }
}
