using Carental.Application.DTOs.Identity;
using Carental.Application.Enums;

namespace Carental.Application.Contracts.Identity
{
    public interface ISignInManager
    {
        public Task<AuthSignInResult> SignIn(SignInRequest request, CancellationToken cancellationToken);

        public Task SignOut(CancellationToken cancellationToken);
    }
}
