
namespace Carental.Application.DTOs.Identity
{
    public record SignInRequest(string Email, string Password, bool RemeberMe = true, bool LockOutOnFailure = true);
}
