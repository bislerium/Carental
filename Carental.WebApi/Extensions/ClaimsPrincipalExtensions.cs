using System.Security.Claims;

namespace Carental.WebApi.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetCurrentSignedInUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
