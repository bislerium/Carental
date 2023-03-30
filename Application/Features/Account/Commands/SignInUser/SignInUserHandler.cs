using Application.Abstractions.CQRS.Command;
using Application.Contracts.Identity;
using Application.Enums;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.Commands.SignInUser
{
    internal class SignInUserHandler : ICommandHandler<SignInUserCommand, AuthSignInResult>
    {
        private readonly IAuthSignInManager _authSignInManager;

        public SignInUserHandler(IAuthSignInManager authSignInManager)
        {
            _authSignInManager = authSignInManager;
        }

        public async Task<Result<AuthSignInResult>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            return await _authSignInManager.SignIn(request.Request, cancellationToken);
        }
    }
}
