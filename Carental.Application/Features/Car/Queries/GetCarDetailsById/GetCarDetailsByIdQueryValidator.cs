using FluentValidation;

namespace Carental.Application.Features.Car.Queries.GetCarDetailsById
{
    public class GetCarDetailsByIdQueryValidator : AbstractValidator<GetCarDetailsByIdQuery>
    {
        public GetCarDetailsByIdQueryValidator()
        {
            RuleFor(x => x.CarId)
                .Must(IsValidGuid)
                .WithMessage("Invalid Id.")
                .NotEmpty();
        }

        private bool IsValidGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}
