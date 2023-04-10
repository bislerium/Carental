using FluentValidation;

namespace Carental.Application.Features.Car.Commands.CreateCar
{
    internal class CreateCarCommandValidator: AbstractValidator<CreateCarCommand>
    {
        CreateCarCommandValidator() 
        {
            RuleFor(x => x.CreateCarRequest.Make)
                .NotEmpty();

            RuleFor(x => x.CreateCarRequest.Model)
                .NotEmpty();

            RuleFor(x => x.CreateCarRequest.Year)
                .Must(BeAValidYear)
                .WithMessage("Year must be a valid date.");

            RuleFor(x => x.CreateCarRequest.Color)
                .NotEmpty();

            RuleFor(x => x.CreateCarRequest.Seats)
                .GreaterThan(0)
                .LessThanOrEqualTo(16) //Folowing EU rules for maximum passenger seats
                .WithMessage("Number of seats must be exclusively between 0 to 16!");

            RuleFor(x => x.CreateCarRequest.CarType)
                .NotNull();

            RuleFor(x => x.CreateCarRequest.FuelType)
                .NotNull();
        }

        private bool BeAValidYear(DateOnly year)
        {
            return year.Year >= 1900 && year.Year <= DateTime.Now.Year;
        }
    }
}
