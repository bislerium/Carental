using Carental.Application.DTOs.Identity;
using Carental.Application.Enums;

namespace Carental.Application.Contracts.Identity
{
    public interface ISignInManager
    {
        public Task<AuthSignInResult> SignInAsync(SignInRequest request, CancellationToken cancellationToken);

        public Task SignOutAsync(CancellationToken cancellationToken);
    }
}
