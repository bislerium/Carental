using Carental.Application.DTOs.Persistence.Rental;

namespace Carental.Application.Contracts.Persistence.ComplexQuery
{
    public interface IGetRentals
    {
        IAsyncEnumerable<CarRentalsResponseDTO> Execute(CancellationToken cancellationToken);
    }
}
