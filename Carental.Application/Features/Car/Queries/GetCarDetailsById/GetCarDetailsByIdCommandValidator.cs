using FluentValidation;

namespace Carental.Application.Features.Car.Queries.GetCarDetailsById
{
    public class GetCarDetailsByIdCommandValidator : AbstractValidator<GetCarDetailsByIdCommand>
    {
        public GetCarDetailsByIdCommandValidator()
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
