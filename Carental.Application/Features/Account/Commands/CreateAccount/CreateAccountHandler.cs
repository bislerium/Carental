using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Identity;
using Carental.Application.DTOs.Persistence;
using Carental.Domain.Entities;
using Carental.Domain.UnitOfWork;
using FluentResults;
using Mapster;

namespace Carental.Application.Features.Account.Commands.CreateAccount
{
    public sealed class CreateAccountHandler : ICommandHandler<CreateAccountCommand>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IUserManager _userManager;

        public CreateAccountHandler(IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _UnitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            CreateAccountRequest createAccountRequest = request.CreateAccountRequest;
            CreateCustomerRequest createCustomerRequest = request.CreateCustomerRequest;

            try
            {
                string accountId = await _userManager.CreateAccount(createAccountRequest);

                Customer customer = createCustomerRequest.Adapt<Customer>();
                customer.Id = accountId;

                _UnitOfWork.CustomerRepository.Add(customer);
                await _UnitOfWork.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            
        }
    }
}
