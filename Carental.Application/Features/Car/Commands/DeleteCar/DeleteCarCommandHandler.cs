using Carental.Application.Abstractions.CQRS.Command;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Car.Commands.DeleteCar
{
    internal class DeleteCarCommandHandler : ICommandHandler<DeleteCarCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCarCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Car? car = await unitOfWork.CarRepository.FindByIdAsync(request.CarId);

            if (car is null) 
            {
                Result.Fail(new Error("No car found wtih given ID!"));    
            }

            try
            {
                unitOfWork.CarRepository.Delete(car!);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail(new Error("Cannot Delete the "));
            }            
        }
    }
}
