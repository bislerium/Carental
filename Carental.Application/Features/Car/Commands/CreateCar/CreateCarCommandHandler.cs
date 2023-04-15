using Carental.Application.Abstractions.CQRS.Command;
using Carental.Domain.UnitOfWork;
using FluentResults;
using Mapster;

namespace Carental.Application.Features.Car.Commands.CreateCar
{
    public class CreateCarCommandHandler : ICommandHandler<CreateCarCommand, Domain.Entities.Car>
    {

        private readonly IUnitOfWork unitOfWork;

        public CreateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                Domain.Entities.Car car = request.CreateCarRequest.Adapt<Domain.Entities.Car>();
                unitOfWork.CarRepository.Add(car);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Ok(car);
            }
            catch (Exception)
            {
                return Result.Fail(new Error("Car creation failed!"));
            }
        }
    }
}
