using Carental.Application.Abstractions.CQRS.Command;
using Carental.Domain.Entities;
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
                _unitOfWork
                    .CarInventoryRepository
                    .Update(rental.CarInventoryId, c => c.IsRented, false);

                rental.IsReturned = true;
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok();
            }

            return Result.Fail(errorMessage);
        }
    }
}
