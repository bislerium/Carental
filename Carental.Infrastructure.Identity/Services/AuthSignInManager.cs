using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Identity;
using Carental.Application.Enums;
using Carental.Application.Exceptions;
using Carental.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Carental.Infrastructure.Identity.Services
{
    internal class AuthSignInManager : ISignInManager
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfigurationSection _jwtSection;

        public AuthSignInManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSection = configuration.GetRequiredSection("Jwt");
        }

        public async Task<(AuthSignInResult, string?)> SignInAsync(SignInRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new NotFoundException();
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RemeberMe, true);

            return (Enum.Parse<AuthSignInResult>(result.ToString(), ignoreCase: true), GenerateToken(user));
        }

        public async Task SignOutAsync(CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
        }

        public string GenerateToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSection["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSection["Issuer"],                
                //audience: _jwtSection["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSection["ExpirationInMinutes"])),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
