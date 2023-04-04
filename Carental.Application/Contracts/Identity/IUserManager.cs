using Carental.Application.DTOs.Identity;

namespace Carental.Application.Contracts.Identity
{
    public interface IUserManager
    {
        public Task<string> CreateAccount(CreateAccountRequest createAccountRequest);
    }
}
