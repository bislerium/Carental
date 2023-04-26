using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Identity;
using Carental.Application.Enums;
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
            AppUser user = await _userManager.FindByEmailAsync(request.Email) ?? new AppUser();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (result.Succeeded)
            {
                return (AuthSignInResult.SUCCESS, await GenerateToken(user, request.RemeberMe));
            }            
            
            return (Enum.Parse<AuthSignInResult>(result.ToString(), ignoreCase: true), null);
        }

        public async Task SignOutAsync(CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
        }

        private async Task<string> GenerateToken(AppUser user, bool extendedExpiration = true)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!)
            }
            .Union(roleClaims)
            .Union(userClaims);
            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSection["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expirationInMinutes = Convert.ToDouble(extendedExpiration 
                ? _jwtSection["ExtendedExpiryInMinutes"]
                : _jwtSection["ExpirationInMinutes"]);

            var token = new JwtSecurityToken(
                issuer: _jwtSection["Issuer"],  
                audience: _jwtSection["Audience"],           
                claims: claims,
                expires: DateTime.Now.AddMinutes(expirationInMinutes),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
