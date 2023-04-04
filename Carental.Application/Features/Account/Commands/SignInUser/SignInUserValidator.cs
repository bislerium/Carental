using FluentValidation;

namespace Carental.Application.Features.Account.Commands.SignInUser
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
