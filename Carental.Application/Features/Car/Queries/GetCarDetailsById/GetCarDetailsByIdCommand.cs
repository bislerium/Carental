using Carental.Application.Abstractions.CQRS.Query;
using Carental.Application.DTOs.Persistence.Car;

namespace Carental.Application.Features.Car.Queries.GetCarDetailsById
{
    public record GetCarDetailsByIdCommand(string CarId) : IQuery<CarDetailResponse>;
}
