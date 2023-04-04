using Carental.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carental.Application.DTOs.Persistence
{
    public class CreateCustomerRequest
    {
        [NotMapped]
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public Gender Gender { get; set; }

        public string Address { get; set; } = null!;

    }
}
