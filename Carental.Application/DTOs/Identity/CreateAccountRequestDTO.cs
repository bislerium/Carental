using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Identity
{
    public class CreateAccountRequestDTO
    {        
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public UserRole Role { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

    }
}
