﻿using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Error;
using Carental.Application.DTOs.Identity;
using Carental.Application.Exceptions.CRUD;
using Carental.Infrastructure.Identity.Entities;
using Carental.Infrastructure.Identity.Extensions;
using Mapster;
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

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            _userManager
                .Users
                .Select(x => new {
                    Id = x.Id,
                    UserName = x.UserName,
                    NormalizedUserName = x.NormalizedUserName,
                    Email = x.Email,
                    NormalizedEmail = x.NormalizedEmail,
                    EmailConfirmed = x.EmailConfirmed,
                    PasswordHash = x.PasswordHash,
                    PhoneNumber = x.PhoneNumber,
                    PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                    TwoFactorEnabled = x.TwoFactorEnabled,
                    LockoutEnd = x.LockoutEnd,
                    LockoutEnabled = x.LockoutEnabled,
                    AccessFailedCount = x.AccessFailedCount
                });
           var users = _userManager.Users.Adapt<IEnumerable<User>>();
            return users;
        }

        public Task<IEnumerable<User>> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
