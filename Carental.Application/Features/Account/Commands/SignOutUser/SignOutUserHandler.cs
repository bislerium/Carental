using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.Contracts.Identity;
using FluentResults;

namespace Carental.Application.Features.Account.Commands.SignOutUser
{
    public class SignOutUserHandler : ICommandHandler<SignOutUserCommand>
    {
        public readonly ISignInManager signInManager;

        public SignOutUserHandler(ISignInManager signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<Result> Handle(SignOutUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await signInManager.SignOutAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();
        }
    }
}
