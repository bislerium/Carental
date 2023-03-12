using Application.Abstractions.CQRS.Command;
using Domain.UnitOfWork;
using FluentResults;

namespace Application.Features.Account.CreateAccount
{
    public sealed class CreateAccountHandler : ICommandHandler<CreateAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Result> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
