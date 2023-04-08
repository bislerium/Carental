using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Identity;
using Carental.Application.Enums;

namespace Carental.Application.Features.Account.Commands.SignInUser
{
    public record SignInUserCommand(SignInRequest Request) : ICommand;
}
