using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Persistence.Rental;
using Carental.Application.Extensions;
using Carental.Domain.Entities;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Rental.Commands.RentCar
{
    internal class RentCarCommandHandler : ICommandHandler<RentCarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RentCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RentCarCommand request, CancellationToken cancellationToken)
        {
            RentCarRequestDTO dto = request.RentCarRequest;

            if (dto.RequestDate < DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return Result.Fail("Must book one day prior.");
            }

            DiscountOffer? offers = await _unitOfWork
                .DiscountOfferRepository
                .FindAsync(d => d.Code == request.RentCarRequest.VoucherCode && DateTime.UtcNow < d.EndDate, cancellationToken: cancellationToken);

            if (offers is null)
            {
                return Result.Fail("Wrong discount voucer code.");
            }

            CarInventory? carInventory  = await _unitOfWork.CarInventoryRepository.FindByIdAsync(dto.CarId, cancellationToken);            

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
                    DiscountOfferId = offers.Id,
                };

                _unitOfWork.CarRentalRepository.Add(carRental);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok();
            }
            
            return Result.Fail(errorMessage);
        }
    }
}
