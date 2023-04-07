using Carental.Domain.Enums;

namespace Carental.Application.DTOs.Persistence
{
    public class CreateCustomerRequest
    {
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public Gender Gender { get; set; }

        public string Address { get; set; } = null!;

    }
}
