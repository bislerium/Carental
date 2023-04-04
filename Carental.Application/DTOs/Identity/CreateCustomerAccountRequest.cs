using Carental.Application.DTOs.Persistence;

namespace Carental.Application.DTOs.Identity
{
    public class CreateCustomerAccountRequest
    {
        public CreateAccountRequest CreateAccountRequest { get; set; }
        public CreateCustomerRequest CreateCustomerRequest { get; set; }
    }
}
