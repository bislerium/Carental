using Carental.Application.DTOs.Identity;

namespace Carental.Application.Contracts.Identity
{
    public interface IUserManager
    {
        public Task<string> CreateAccount(CreateAccountRequest createAccountRequest);

        public Task<IEnumerable<User>> getAllUsersAsync(CancellationToken cancellationToken = default);

        public Task<IEnumerable<User>> getUserByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
