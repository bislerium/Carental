using Carental.Application.Abstractions.CQRS.Query;
using Carental.Application.DTOs.Persistence.Car;

namespace Carental.Application.Features.Car.Queries.GetCars
{
    public record GetCarsQuery(): IQuery<IEnumerable<CarSummaryResponse>>;
}
