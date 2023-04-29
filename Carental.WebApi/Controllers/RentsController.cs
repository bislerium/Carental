using Carental.Application.DTOs.Persistence.Rental;
using Carental.Application.Features.Rental.Commands.CancelRentedCar;
using Carental.Application.Features.Rental.Commands.RentCar;
using Carental.Application.Features.Rental.Commands.ReturnRentedCar;
using Carental.WebApi.Extensions;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carental.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class RentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> Rent(RentCarRequestDTO rentCarRequest)
        {
            RentCarCommand command = new(User.GetCurrentSignedInUserId()!, rentCarRequest);
            Result result = await _mediator.Send(command);

            return result.IsSuccess
                ? Ok()
                : BadRequest(result.Reasons);
        }

        [HttpPost("{rentId:guid}/[action]")]
        public async Task<IActionResult> Cancel(string rentId) 
        {
            CancelRentedCarCommand command = new(User.GetCurrentSignedInUserId()!, rentId);
            Result result = await _mediator.Send(command);
            return result.IsSuccess
                ? Ok()
                : BadRequest(result.Reasons);
        }

        [HttpPost("{rentId:guid}/[action]")]
        [Authorize(Roles = "Staff, Admin")]
        public async Task<IActionResult> Return(string rentId)
        {
            ReturnRentedCarCommand command = new(rentId);
            Result result = await _mediator.Send(command);
            return result.IsSuccess
                ? Ok()
                : BadRequest(result.Reasons);
        }
    }
}
