using Carental.Application.DTOs.Identity;
using Carental.Application.DTOs.Persistence;
using Carental.Application.Features.Account.Commands.CreateAccount;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Controllers;

namespace Carental.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register(CreateCustomerAccountRequest createCustomerAccountRequest) 
        {
            CreateAccountCommand command = new(createCustomerAccountRequest.CreateAccountRequest, createCustomerAccountRequest.CreateCustomerRequest);
            Result result = await _mediator.Send(command);
            return result.IsSuccess 
                ? CreatedAtAction(nameof(WeatherForecastController.Get), new { }) 
                : BadRequest(result.Reasons);
        }
    }
}
