using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Identity;
using Carental.Application.DTOs.Persistence;

namespace Carental.Application.Features.Account.Commands.CreateAccount
{
    public sealed record CreateAccountCommand(CreateAccountRequest CreateAccountRequest, CreateCustomerRequest CreateCustomerRequest) : ICommand;
}
