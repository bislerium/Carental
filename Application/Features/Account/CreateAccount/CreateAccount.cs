using Application.Abstractions.CQRS.Command;

namespace Application.Features.Account.CreateAccount
{
    public sealed record CreateAccount(): ICommand;
}
