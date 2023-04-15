using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Persistence.Car;

namespace Carental.Application.Features.Car.Commands.CreateCar
{
    public record CreateCarCommand (CreateCarRequest CreateCarRequest): ICommand<Domain.Entities.Car>;
}
