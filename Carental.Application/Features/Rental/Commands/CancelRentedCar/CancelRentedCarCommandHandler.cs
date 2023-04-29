using Carental.Application.Abstractions.CQRS.Command;
using Carental.Domain.Entities;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Rental.Commands.CancelRentedCar
{
    public class CancelRentedCarCommandHandler : ICommandHandler<CancelRentedCarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelRentedCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CancelRentedCarCommand request, CancellationToken cancellationToken)
        {
            CarRental? rental = await _unitOfWork.CarRentalRepository.FindByIdAsync(request.RentId, cancellationToken);

            string errorMessage;

            if (rental == null)
            {
                errorMessage = "Cannot find car rent by given id.";
            }
            else if (!rental.CustomerId.Equals(request.UserId))
            {
                errorMessage = "Cannot cancel the car rent";
            }
            else if (rental.IsCancelled) 
            {
                errorMessage = "The car rent was already cancelled.";
            }
            else if (rental.IsReturned)
            {
                errorMessage = "The car rent was returned.";
            }
            else
            {
                _unitOfWork
                    .CarInventoryRepository
                    .Update(rental.CarInventoryId, c => c.IsRented, false);

                rental.IsCancelled = true;
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok();
            }

            return Result.Fail(errorMessage);
        }
    }
}
