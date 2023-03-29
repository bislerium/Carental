using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Identity
{
    public record SignInRequest(string Email, string Password, bool RemeberMe = true, bool LockOutOnFailure = true);
}
