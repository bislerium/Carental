using Carental.Application.Abstractions.CQRS.Query;
using Carental.Application.DTOs.Persistence.Car;
using Carental.Domain.UnitOfWork;
using FluentResults;
using Mapster;

namespace Carental.Application.Features.Car.Queries.GetCarDetailsById
{
    public class GetCarDetailsByIdCommandHandler : IQueryHandler<GetCarDetailsByIdCommand, CarDetailResponse>
    {

        private readonly IUnitOfWork unitOfWork;

        public GetCarDetailsByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<CarDetailResponse>> Handle(GetCarDetailsByIdCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Car? car = await unitOfWork.CarRepository.FindByIdAsync(request.CarId, cancellationToken);

            if (car == null)
            {
                return Result.Fail(new Error("No car found with given Id."));
            }

            CarDetailResponse carDetail = car.Adapt<CarDetailResponse>();

            carDetail.RentalRate = car.CarInventory?.RentalRate ?? 0;
            carDetail.IsRented = car.CarInventory?.IsRented ?? false;

            return Result.Ok(carDetail);
        }
    }
}
