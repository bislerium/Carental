﻿using Carental.Application.DTOs.Identity;
using Carental.Application.Enums;
using Carental.Application.Features.Account.Commands.CreateAccount;
using Carental.Application.Features.Account.Commands.SignInUser;
using Carental.Application.Features.Account.Commands.SignOutUser;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carental.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Register(CreateCustomerAccountRequest createCustomerAccountRequest) 
        {
            CreateAccountCommand command = new(createCustomerAccountRequest);
            Result result = await _mediator.Send(command);            
            return result.IsSuccess 
                ? Ok("User successfully regustered!")
                : BadRequest(result.Reasons);
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest signInRequest) 
        { 
            SignInUserCommand signInUserCommand = new(signInRequest);
            Result<string> result = await _mediator.Send(signInUserCommand);
            return result.IsSuccess
                ? Ok(new { token = result.Value })
                : BadRequest(result.Reasons);
        }

        [Route("signout")]
        [HttpPost]        
        public new async Task<IActionResult> SignOut()
        {
            SignOutUserCommand signOutUserCommand = new();
            Result<AuthSignInResult> result = await _mediator.Send(signOutUserCommand);
            return result.IsSuccess
                ? Ok()
                : BadRequest(result.Reasons);
        }
    }
}
