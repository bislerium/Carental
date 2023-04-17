using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.Contracts.Identity;
using Carental.Application.Enums;
using Carental.Application.Extensions;
using FluentResults;

namespace Carental.Application.Features.Account.Commands.SignInUser
{
    internal class SignInUserHandler : ICommandHandler<SignInUserCommand, string>
    {
        private readonly ISignInManager _authSignInManager;

        public SignInUserHandler(ISignInManager authSignInManager)
        {
            _authSignInManager = authSignInManager;
        }

        public async Task<Result<string>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            try {
                (AuthSignInResult result, string? token) = await _authSignInManager.SignInAsync(request.Request, cancellationToken);

                if (result is AuthSignInResult.SUCCEEDED)
                    return Result.Ok(token ?? String.Empty);

                Error error = new("Signin Failed!");
                error.WithMetadata(nameof(result), result.Message());
                return Result.Fail(error);
                
            }
            catch (Exception ex)
            {
                 return Result.Fail(ex.Message);
            }
        }

    }
}
