using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Persistence.Rental;

namespace Carental.Application.Features.Rental.Commands.RentCar
{
    public record RentCarCommand(string UserId, RentCarRequestDTO RentCarRequest) : ICommand;
}
