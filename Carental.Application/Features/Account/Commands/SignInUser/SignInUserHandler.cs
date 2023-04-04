using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.Contracts.Identity;
using Carental.Application.Enums;
using FluentResults;

namespace Carental.Application.Features.Account.Commands.SignInUser
{
    internal class SignInUserHandler : ICommandHandler<SignInUserCommand, AuthSignInResult>
    {
        private readonly ISignInManager _authSignInManager;

        public SignInUserHandler(ISignInManager authSignInManager)
        {
            _authSignInManager = authSignInManager;
        }

        public async Task<Result<AuthSignInResult>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            return await _authSignInManager.SignIn(request.Request, cancellationToken);
        }
    }
}
