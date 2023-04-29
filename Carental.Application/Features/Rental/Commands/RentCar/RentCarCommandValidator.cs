using FluentValidation;

namespace Carental.Application.Features.Rental.Commands.RentCar
{
    internal class RentCarCommandValidator: AbstractValidator<RentCarCommand>
    {
        public RentCarCommandValidator()
        {
            RuleFor(r => r.RentCarRequest.CarId)
                .Must(IsValidId)
                .WithMessage("Invalid car id.");

            RuleFor(r => r.UserId)
                .Must(IsValidId)
                .WithMessage("Invalid user id.");

            RuleFor(r => r.RentCarRequest.RequestDate)
                .Must(IsValidRequestDate)
                .WithMessage("Request date must be 1 day prior.");
        }

        private bool IsValidId(string id)
        {
            return Guid.TryParse(id, out _);
        }

        private bool IsValidRequestDate(DateOnly requestDate)
        {
            DateOnly availableAt = DateOnly.FromDateTime(DateTime.UtcNow).AddDays(1);
            return requestDate >= availableAt;
        }
    }
}
