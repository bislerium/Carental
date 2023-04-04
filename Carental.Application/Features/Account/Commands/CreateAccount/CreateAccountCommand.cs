using Carental.Application.Abstractions.CQRS.Command;

namespace Carental.Application.Features.Account.Commands.CreateAccount
{
    public sealed record CreateAccountCommand() : ICommand;
}
