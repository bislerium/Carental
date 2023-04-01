using Application.DTOs.Identity;
using Application.Enums;

namespace Application.Contracts.Identity
{
    public interface ISignInManager
    {
        public Task<AuthSignInResult> SignIn(SignInRequest request, CancellationToken cancellationToken);

        public Task SignOut(CancellationToken cancellationToken);
    }
}
