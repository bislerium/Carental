using Carental.Application.Abstractions.CQRS.Command;
using Carental.Application.DTOs.Persistence.Rental;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Rental.Queries.GetAllRentals
{
    internal class GetAllRentalsQueryHandler : ICommandHandler<GetAllRentalsQuery, IEnumerable<CarRentalsResponseDTO>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllRentalsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Result<IEnumerable<CarRentalsResponseDTO>>> Handle(GetAllRentalsQuery request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
