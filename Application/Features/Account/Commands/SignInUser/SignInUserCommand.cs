using Application.Abstractions.CQRS.Command;
using Application.DTOs.Identity;
using Application.Enums;

namespace Application.Features.Account.Commands.SignInUser
{
    public record SignInUserCommand(SignInRequest Request) : ICommand<AuthSignInResult>;
}
