using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carental.Application.Features.Rental.Commands.RentACar
{
    internal class RentACarCommandValidator: AbstractValidator<RentACarCommand>
    {
        public RentACarCommandValidator()
        {
            RuleFor(r => r.RentACarRequest.CarId)
                .Must(IsValidId)
                .WithMessage("Invalid car id.");

            RuleFor(r => r.RentACarRequest.UserId)
                .Must(IsValidId)
                .WithMessage("Invalid use id.");                
        }

        private bool IsValidId(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}
