using Application.Abstractions.CQRS.Command;

namespace Application.Features.Account.Commands.CreateAccount
{
    public sealed record CreateAccountCommand() : ICommand;
}
