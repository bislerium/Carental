using Carental.Application.Abstractions.CQRS.Command;

namespace Carental.Application.Features.Rental.Commands.CancelRentedCar
{
    public record CancelRentedCarCommand(string UserId, string RentId) : ICommand;
}
