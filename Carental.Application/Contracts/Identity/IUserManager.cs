using Carental.Application.DTOs.Identity;
using System.Runtime.CompilerServices;

namespace Carental.Application.Contracts.Identity
{
    public interface IUserManager
    {
        public Task<string> CreateAccount(CreateAccountRequestDTO createAccountRequest);

        public IAsyncEnumerable<User> GetAllUsersAsync(CancellationToken cancellationToken = default);

        public Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
