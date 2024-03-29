﻿using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Error;
using Carental.Application.DTOs.Identity;
using Carental.Application.Exceptions.CRUD;
using Carental.Domain.Enums;
using Carental.Infrastructure.Identity.Entities;
using Carental.Infrastructure.Identity.Extensions;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

        public async Task<string> CreateAccount(CreateAccountRequestDTO createAccountRequest)
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
                string messageTitle = "User creation failed!";
                createAccountResult.Errors.ToErrors(messageTitle, out Errors errors);
                throw new CreateFailedException(typeof(AppUser), errors);
            }

            IdentityResult createRoleResult = await _userManager.AddToRoleAsync(user, createAccountRequest.Role.ToString());

            if (!createRoleResult.Succeeded)
            {
                string messageTitle = "Role assignment failed!";
                createRoleResult.Errors.ToErrors(messageTitle, out Errors errors);
                throw new CreateFailedException(typeof(IdentityRole), errors);
            }

            return user.Id;
        }

        public async IAsyncEnumerable<User> GetAllUsersAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
          
            await foreach(AppUser appUser in _userManager.Users.AsAsyncEnumerable().WithCancellation(cancellationToken))
            {
                User user = appUser.Adapt<User>();
                user.Role = await GetUserRole(appUser);
                yield return user;
            }
        }

        public async Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            IdentityUser? user = await _userManager.FindByIdAsync(id);
            return user?.Adapt<User>();
        }

        private async Task<UserRole> GetUserRole(AppUser user) {
            var r = await _userManager.GetRolesAsync(user);
            return Enum.Parse<UserRole>(r.First());
        }
    }
}
