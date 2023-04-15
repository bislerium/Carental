using Carental.Application.DTOs.Persistence.Car;
using Carental.Application.Features.Car.Commands.CreateCar;
using Carental.Application.Features.Car.Commands.DeleteCar;
using Carental.Application.Features.Car.Queries.GetCarDetailsById;
using Carental.Application.Features.Car.Queries.GetCars;
using Carental.Domain.Entities;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carental.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {

        public IMediator mediator;

        public CarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("/[controller]s")]
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            GetCarsCommand command = new();
            Result<IEnumerable<Car>> result = await mediator.Send(command);
            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest();
        }


        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Detail([FromRoute] string id)
        {
            GetCarDetailsByIdCommand command = new(id);
            Result<CarDetailResponse> result = await mediator.Send(command);
            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Reasons);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCarRequest createCarRequest)
        {
            CreateCarCommand command = new(createCarRequest);
            Result<Car> result = await mediator.Send(command);
            return result.IsSuccess
                ? CreatedAtAction(nameof(Detail),new { id = result.Value.Id }, result.Value)
                : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(CreateCarRequest createCarRequest)
        {
            CreateCarCommand command = new(createCarRequest);
            Result<Car> result = await mediator.Send(command);
            return result.IsSuccess
                ? CreatedAtAction(nameof(Detail), new { id = result.Value.Id }, result.Value)
                : BadRequest();
        }


        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            DeleteCarCommand command = new(id);
            Result result = await mediator.Send(command);
            return result.IsSuccess
                ? Ok()
                : BadRequest();
        }
    }
}
