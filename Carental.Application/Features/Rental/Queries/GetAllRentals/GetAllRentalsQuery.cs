using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Persistence.Rental;

namespace Carental.Application.Features.Rental.Queries.GetAllRentals
{
    public record GetAllRentalsQuery(): ICommand<IEnumerable<CarRentalsResponseDTO>>;
}
