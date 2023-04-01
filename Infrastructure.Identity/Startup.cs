﻿using Application.Contracts.Identity;
using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.Entities;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity
{
    public static class Startup
    {
        public static void AddInfrastructureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<IdentityDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("IdentityDB"));
                });

            services
                .AddIdentity<AppUser, IdentityRole>(options => 
                {
                    options.Password.RequiredUniqueChars = 5;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;

                    options.SignIn.RequireConfirmedAccount = true;
                    options.SignIn.RequireConfirmedEmail = true;

                    options.Lockout.AllowedForNewUsers = false;
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(5);
                })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ISignInManager, AuthSignInManager>();

            services.AddScoped<IUserManager, AuthUserManager>();
        }
    }
}
