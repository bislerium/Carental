using Carental.Application.Abstractions.CQRS.Command;
using Carental.Domain.UnitOfWork;
using FluentResults;
using Mapster;

namespace Carental.Application.Features.Car.Commands.CreateCar
{
    public class CreateCarCommandHandler : ICommandHandler<CreateCarCommand>
    {

        private readonly IUnitOfWork unitOfWork;

        public CreateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                Domain.Entities.Car car = request.CreateCarRequest.Adapt<Domain.Entities.Car>();
                unitOfWork.CarRepository.Add(car);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                return Result.Fail(new Error("Car creation failed!"));
            }
            return Result.Ok();
        }
    }
}
