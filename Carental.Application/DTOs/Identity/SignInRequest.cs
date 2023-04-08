
using System.ComponentModel.DataAnnotations.Schema;

namespace Carental.Application.DTOs.Identity
{
    public record SignInRequest(string Email, string Password, bool RemeberMe = true);
}
