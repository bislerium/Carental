using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Identity
{
    public class CreateCustomerAccountRequest
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public UserRole Role { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public Gender Gender { get; set; }

        public string Address { get; set; } = null!;
    }
}
