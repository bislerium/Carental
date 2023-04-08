using Carental.Application.Abstractions.CQRS.Command;

namespace Carental.Application.Features.Account.Commands.SignOutUser
{
    public record SignOutUserCommand() : ICommand;
}
