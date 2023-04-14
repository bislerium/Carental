using Carental.Application.DTOs.Persistence.Car;
using Carental.Application.Features.Car.Commands.CreateCar;
using Carental.Application.Features.Car.Commands.DeleteCar;
using Carental.Application.Features.Car.Queries.GetCars;
using Carental.Domain.Entities;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            GetCarsCommand command = new();
            Result<IEnumerable<Car>> result = await mediator.Send(command);
            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCarRequest createCarRequest)
        {
            CreateCarCommand command = new(createCarRequest);
            Result result = await mediator.Send(command);
            return result.IsSuccess
                ? Ok()
                : BadRequest();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            DeleteCarCommand command = new(id);
            Result result = await mediator.Send(command);
            return result.IsSuccess
                ? Ok()
                : BadRequest();
        }
    }
}
