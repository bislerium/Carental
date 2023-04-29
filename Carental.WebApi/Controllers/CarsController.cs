using Carental.Application.DTOs.Persistence.Car;
using Carental.Application.Features.Car.Commands.CreateCar;
using Carental.Application.Features.Car.Commands.DeleteCar;
using Carental.Application.Features.Car.Queries.GetCarDetailsById;
using Carental.Application.Features.Car.Queries.GetCars;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carental.WebApi.Controllers
{
    [Authorize(Roles = "Admin, Staff")]
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {

        public readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
      
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() {
            GetCarsQuery command = new();
            Result<IEnumerable<CarSummaryResponseDTO>> result = await _mediator.Send(command);
            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest();
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Detail([FromRoute] string id)
        {
            GetCarDetailsByIdQuery command = new(id);
            Result<CarDetailResponseDTO> result = await _mediator.Send(command);
            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Reasons);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCarRequestDTO createCarRequest)
        {
            CreateCarCommand command = new(createCarRequest);
            Result<CarDetailResponseDTO> result = await _mediator.Send(command);
            return result.IsSuccess
                ? CreatedAtAction(nameof(Detail),new { id = result.Value.Id }, result.Value)
                : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(CreateCarRequestDTO createCarRequest)
        {
            CreateCarCommand command = new(createCarRequest);
            Result<CarDetailResponseDTO> result = await _mediator.Send(command);
            return result.IsSuccess
                ? CreatedAtAction(nameof(Detail), new { id = result.Value.Id }, result.Value)
                : BadRequest();
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            DeleteCarCommand command = new(id);
            Result result = await _mediator.Send(command);
            return result.IsSuccess
                ? Ok()
                : BadRequest();
        }
    }
}
