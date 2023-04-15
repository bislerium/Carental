using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Persistence.Car;
using Carental.Domain.Entities;
using Carental.Domain.UnitOfWork;
using FluentResults;
using Mapster;

namespace Carental.Application.Features.Car.Commands.CreateCar
{
    public class CreateCarCommandHandler : ICommandHandler<CreateCarCommand, CarDetailResponse>
    {

        private readonly IUnitOfWork unitOfWork;

        public CreateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<CarDetailResponse>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                Domain.Entities.Car car = request.CreateCarRequest.Adapt<Domain.Entities.Car>();
                CarInventory carInventory = new()
                {
                    Id = car.Id,
                    RentalRate = request.CreateCarRequest.RentalRate,                    
                };

                unitOfWork.CarInventoryRepository.Add(carInventory);
                unitOfWork.CarRepository.Add(car);                
                await unitOfWork.SaveChangesAsync(cancellationToken);

                CarDetailResponse carDetailResponse = car.Adapt<CarDetailResponse>();
                carDetailResponse.RentalRate = carInventory.RentalRate;

                return Result.Ok(carDetailResponse);
            }
            catch (Exception)
            {
                return Result.Fail(new Error("Car creation failed!"));
            }
        }
    }
}
