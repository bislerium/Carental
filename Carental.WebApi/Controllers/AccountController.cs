using Carental.Application.DTOs.Identity;
using Carental.Application.DTOs.Persistence;
using Carental.Application.Features.Account.Commands.CreateAccount;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
            CreateAccountCommand command = new(createCustomerAccountRequest);
            Result result = await _mediator.Send(command);            
            return result.IsSuccess 
                ? Ok("User successfully regustered!")
                : BadRequest(result.Reasons);
        }
    }
}
