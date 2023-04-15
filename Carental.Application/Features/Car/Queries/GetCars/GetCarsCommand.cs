using Carental.Application.Abstractions.CQRS.Query;
using Carental.Application.DTOs.Persistence.Car;

namespace Carental.Application.Features.Car.Queries.GetCars
{
    public record GetCarsCommand(): IQuery<IEnumerable<CarSummaryResponse>>;
}
