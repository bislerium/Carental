using Carental.Application.Abstractions.CQRS.Query;
using Carental.Domain.UnitOfWork;
using FluentResults;

namespace Carental.Application.Features.Car.Queries.GetCars
{
    public class GetCarsHandler : IQueryHandler<GetCarsCommand, IEnumerable<Domain.Entities.Car>>
    {
        public IUnitOfWork unitOfWork;

        public GetCarsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Domain.Entities.Car>>> Handle(GetCarsCommand request, CancellationToken cancellationToken)
        {
            var cars = new List<Domain.Entities.Car>();
            await foreach (var entity in unitOfWork.CarRepository.GetAllAsync(cancellationToken))
            {
                cars.Add(entity);
            }
            return Result.Ok<IEnumerable<Domain.Entities.Car>>(cars);
        }
    }
}
