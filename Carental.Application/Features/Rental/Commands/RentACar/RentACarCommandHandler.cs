using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.Contracts.Identity;
using Carental.Application.DTOs.Persistence.Rental;
using Carental.Domain.Entities;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Rental.Commands.RentACar
{
    internal class RentACarCommandHandler : ICommandHandler<RentACarCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserManager userManager;
        public RentACarCommandHandler(IUnitOfWork unitOfWork, IUserManager userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<Result> Handle(RentACarCommand request, CancellationToken cancellationToken)
        {
            RentACarRequest rentACarRequest = request.RentACarRequest;

            CarInventory? carInventory  = await unitOfWork.CarInventoryRepository.FindByIdAsync(rentACarRequest.CarId, cancellationToken);
            if (carInventory == null)
            {
                return Result.Fail(new Error("Car with given Id not found."));
            }
            Customer? customer = await unitOfWork.CustomerRepository.FindByIdAsync(rentACarRequest.UserId, cancellationToken);
            
            if (customer == null)
            {
                return Result.Fail(new Error("Customer with given by Id not found."));
            }

            CarRental carRental = new ()
            {
                CustomerId = customer.Id,
                CarInventoryId = carInventory.Id,
                RequestDate = DateOnly.FromDateTime(DateTime.UtcNow),
            };

            unitOfWork.CarRentalRepository.Add(carRental);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
