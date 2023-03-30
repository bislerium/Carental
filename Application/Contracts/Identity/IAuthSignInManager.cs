using Application.DTOs.Identity;
using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Identity
{
    public interface IAuthSignInManager
    {
        public Task<AuthSignInResult> SignIn(SignInRequest request, CancellationToken cancellationToken);

        public Task SignOut(CancellationToken cancellationToken);
    }
}
