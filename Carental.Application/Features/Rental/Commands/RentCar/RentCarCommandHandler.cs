using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Persistence.Rental;
using Carental.Domain.Entities;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Rental.Commands.RentCar
{
    internal class RentCarCommandHandler : ICommandHandler<RentCarCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public RentCarCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RentCarCommand request, CancellationToken cancellationToken)
        {
            RentCarRequestDTO dto = request.RentCarRequest;

            CarInventory? carInventory  = await unitOfWork.CarInventoryRepository.FindByIdAsync(dto.CarId, cancellationToken);

            string errorMessage;

            if (carInventory == null)
            {
                errorMessage = "Car with given Id not found.";
            }
            else if (carInventory.IsRented)
            {
                errorMessage = "The Car is already rented,";
            }
            else
            {

                carInventory.IsRented = true;

                CarRental carRental = new()
                {
                    CustomerId = request.UserId,
                    CarInventoryId = carInventory.Id,
                    RequestDate = dto.RequestDate,
                };
                unitOfWork.CarRentalRepository.Add(carRental);

                await unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok();
            }
            
            return Result.Fail(errorMessage);
        }
    }
}
