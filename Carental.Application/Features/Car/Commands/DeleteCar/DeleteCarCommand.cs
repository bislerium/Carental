using Carental.Application.Abstractions.CQRS.Command;

namespace Carental.Application.Features.Car.Commands.DeleteCar
{
    public record DeleteCarCommand(string CarId): ICommand;
}
