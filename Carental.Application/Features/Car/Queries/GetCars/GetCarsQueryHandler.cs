using Carental.Application.Abstractions.CQRS.Query;
using Carental.Application.DTOs.Persistence.Car;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Car.Queries.GetCars
{
    public class GetCarsQueryHandler : IQueryHandler<GetCarsQuery, IEnumerable<CarSummaryResponseDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCarsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<CarSummaryResponseDTO>>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var carSummaries = new List<CarSummaryResponseDTO>();
            await foreach (var entity in unitOfWork.CarRepository.GetAllAsync(cancellationToken))
            {
                CarSummaryResponseDTO carSummary = new()
                {
                    Id = entity.Id,
                    Make = entity.Make,
                    Model = entity.Model,
                    Year = entity.Year.Year,
                    RentalRate = entity.CarInventory.RentalRate,
                    IsRented = entity.CarInventory.IsRented,
                };
                carSummaries.Add(carSummary);
            }
            return Result.Ok<IEnumerable<CarSummaryResponseDTO>>(carSummaries);
        }
    }
}
