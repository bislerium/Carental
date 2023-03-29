using Domain.Common;

namespace Domain.Entities
{
    public class User: BaseAuditableEntity
    {
        public string? ImageURL { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
}
