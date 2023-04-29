using Carental.Application.Abstractions.CQRS.Query;
using Carental.Application.DTOs.Persistence.Car;
using Carental.Domain.UnitOfWork;
using FluentResults;
using Mapster;

namespace Carental.Application.Features.Car.Queries.GetCarDetailsById
{
    public class GetCarDetailsByIdQueryHandler : IQueryHandler<GetCarDetailsByIdQuery, CarDetailResponseDTO>
    {

        private readonly IUnitOfWork unitOfWork;

        public GetCarDetailsByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<CarDetailResponseDTO>> Handle(GetCarDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Car? car = await unitOfWork.CarRepository.FindByIdAsync(request.CarId, cancellationToken);

            if (car == null)
            {
                return Result.Fail(new Error("No car found with given Id."));
            }

            CarDetailResponseDTO carDetail = car.Adapt<CarDetailResponseDTO>();

            carDetail.RentalRate = car.CarInventory.RentalRate;
            carDetail.IsRented = car.CarInventory.IsRented;

            return Result.Ok(carDetail);
        }
    }
}
