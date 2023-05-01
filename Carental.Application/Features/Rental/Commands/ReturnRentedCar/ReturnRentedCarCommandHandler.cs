using Carental.Application.Abstractions.CQRS.Command;
using Carental.Domain.Entities;
using Carental.Domain.Enums;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Rental.Commands.ReturnRentedCar
{
    internal class ReturnRentedCarCommandHandler : ICommandHandler<ReturnRentedCarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReturnRentedCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ReturnRentedCarCommand request, CancellationToken cancellationToken)
        {
            CarRental? rental =await _unitOfWork.CarRentalRepository.FindByIdAsync(request.RentId, cancellationToken);

            string errorMessage;

            if (rental == null)
            {
                errorMessage = "Cannot find car rent by given id.";
            }
            else if (rental.ApprovalStatus != Domain.Enums.ApprovalStatus.APPROVE)
            {
                errorMessage = "Cannot set the un-approved car as returned.";
            }
            else if (rental.IsCancelled)
            {
                errorMessage = "The car rent was cancelled.";
            }
            else if (rental.IsReturned) 
            {
                errorMessage = "The car rent was already returned.";
            }            
            else
            {
                DiscountOffer? offer = await _unitOfWork
                    .DiscountOfferRepository
                    .FindAsync(x => x.Code == rental.DiscountOfferId, cancellationToken: cancellationToken);

                DateTime returnedDateTime = DateTime.UtcNow;

                int discountRate = offer?.DiscountRate ?? 0;
                int numberOfDaysRented = DateOnly.FromDateTime(returnedDateTime).DayNumber - rental.RequestDate.DayNumber;
                numberOfDaysRented = numberOfDaysRented == 0 ? 1 : numberOfDaysRented;
                decimal rentalRate = rental.CarInventory.RentalRate;

                decimal afterDiscountRentalRatePerDay = (rentalRate - (rentalRate * (discountRate / 100m)));
                decimal finalRentPrice = afterDiscountRentalRatePerDay * numberOfDaysRented;

                _unitOfWork
                    .CarInventoryRepository
                    .Update(rental.CarInventoryId, c => c.IsRented, false);

                rental.IsReturned = true;
                rental.RentPrice = finalRentPrice;
                rental.ReturnOrCancelDateTime = returnedDateTime;

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok();
            }

            return Result.Fail(errorMessage);
        }
    }
}
