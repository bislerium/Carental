using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Persistence.Rental;

namespace Carental.Application.Features.Rental.Commands.RentACar
{
    public record RentACarCommand(RentACarRequest RentACarRequest): ICommand;
}
