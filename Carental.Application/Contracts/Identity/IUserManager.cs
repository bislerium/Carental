using Carental.Application.DTOs.Identity;

namespace Carental.Application.Contracts.Identity
{
    public interface IUserManager
    {
        public Task<string> CreateAccount(CreateAccountRequestDTO createAccountRequest);

        public Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);

        public Task<IEnumerable<User>> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
