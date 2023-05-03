using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Identity
{
    public record User(
        string Id,
        string UserName,
        string NormalizedUserName,
        string Email,
        string NormalizedEmail,
        bool EmailConfirmed,
        string PasswordHash,
        string PhoneNumber,
        bool PhoneNumberConfirmed,
        bool TwoFactorEnabled,
        DateTimeOffset? LockoutEnd,
        bool LockoutEnabled,
        int AccessFailedCount       
        )
    {
        public UserRole Role { get; set; }
    };

}
