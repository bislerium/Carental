using Carental.Application.Abstractions.CQRS.Command;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Account.Commands.CreateAccount
{
    public sealed class CreateAccountHandler : ICommandHandler<CreateAccountCommand>
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CreateAccountHandler(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return Result.Ok();
        }
    }
}
