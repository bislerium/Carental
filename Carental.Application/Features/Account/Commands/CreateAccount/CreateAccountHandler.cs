using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Identity;
using Carental.Application.DTOs.Persistence.Account;
using Carental.Application.Exceptions.CRUD;
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
            CreateAccountRequestDTO createAccountRequest = request.CreateCustomerAccountRequest.Adapt<CreateAccountRequestDTO>();
            CreateCustomerRequestDTO createCustomerRequest = request.CreateCustomerAccountRequest.Adapt<CreateCustomerRequestDTO>();

            try
            {
                string accountId = await _userManager.CreateAccount(createAccountRequest);

                Customer customer = createCustomerRequest.Adapt<Customer>();
                customer.Id = accountId;

                _UnitOfWork.CustomerRepository.Add(customer);
                await _UnitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Ok();
            }
            catch (CreateFailedException cfex)
            {
                var error = new Error(cfex.Errors.Title);
                foreach (var e in cfex.Errors.Values)
                {
                    error.WithMetadata(e.Code, e.Messages);
                }                
                return Result.Fail(error);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            
        }
    }
}
