using Carental.Application.Abstractions.CQRS.Query;

namespace Carental.Application.Features.Car.Queries.GetCars
{
    public record GetCarsCommand(): IQuery<IEnumerable<Domain.Entities.Car>>;
}
