namespace Carental.Application.DTOs.Identity
{
    public record User(
        string Id,
        string UserName,
        string NormalizedUserName,
        string Email,
        string NormalizedEmail,
        // string FullName,
        bool EmailConfirmed,
        string PasswordHash,
        string PhoneNumber,
        bool PhoneNumberConfirmed,
        bool TwoFactorEnabled,
        DateTimeOffset? LockoutEnd,
        bool LockoutEnabled,
        int AccessFailedCount
        );
}
