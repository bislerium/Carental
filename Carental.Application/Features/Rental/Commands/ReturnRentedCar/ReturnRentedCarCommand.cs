using Carental.Application.Abstractions.CQRS.Command;

namespace Carental.Application.Features.Rental.Commands.ReturnRentedCar
{
    public record ReturnRentedCarCommand(string RentId): ICommand;
}