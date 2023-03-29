namespace Application.DTOs.Identity
{
    public record User(
        string UserName,
        string Email,
        string FullName
        );
}
