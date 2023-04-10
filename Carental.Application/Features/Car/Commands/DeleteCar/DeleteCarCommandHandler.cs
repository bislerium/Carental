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
            Domain.Entities.Car? car = unitOfWork.CarRepository.Query().FirstOrDefault(x => x.Id.Equals(request.CarId));

            try
            {
                Domain.Entities.Car car = new()
                {
                    Id = request.CarId
                };
                unitOfWork.CarRepository.Delete(car);
            }
            catch (Exception)
            {
                return Result.Fail(new Error("Cannot Delete the "))
            }

            
        }
    }
}
