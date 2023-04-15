using Carental.Application.Abstractions.CQRS.Query;
using Carental.Application.DTOs.Persistence.Car;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Car.Queries.GetCars
{
    public class GetCarsHandler : IQueryHandler<GetCarsCommand, IEnumerable<CarSummaryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCarsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<CarSummaryResponse>>> Handle(GetCarsCommand request, CancellationToken cancellationToken)
        {
            var carSummaries = new List<CarSummaryResponse>();
            await foreach (var entity in unitOfWork.CarRepository.GetAllAsync(cancellationToken))
            {
                CarSummaryResponse carSummary = new()
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
            return Result.Ok<IEnumerable<CarSummaryResponse>>(carSummaries);
        }
    }
}
