using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.Commands.SignInUser
{
    internal class SignInUserValidator: AbstractValidator<SignInUserCommand>
    {
        public SignInUserValidator() 
        {
            RuleFor(x => x.Request.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Request.Password)
                .NotEmpty();
        }
    }
}
