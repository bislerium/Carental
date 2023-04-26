using Carental.Application.DTOs.Persistence.Car;
using Carental.Application.Features.Car.Commands.CreateCar;
using Carental.Application.Features.Car.Commands.DeleteCar;
using Carental.Application.Features.Car.Queries.GetCarDetailsById;
using Carental.Application.Features.Car.Queries.GetCars;
using Carental.Application.Features.Rental.Commands.RentACar;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carental.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        public IMediator mediator;

        public CarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("/[controller]s")]        
        [HttpGet]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<IActionResult> GetAll() {
            GetCarsQuery command = new();
            Result<IEnumerable<CarSummaryResponse>> result = await mediator.Send(command);
            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest();
        }


        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Detail([FromRoute] string id)
        {
            GetCarDetailsByIdQuery command = new(id);
            Result<CarDetailResponse> result = await mediator.Send(command);
            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Reasons);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCarRequest createCarRequest)
        {
            CreateCarCommand command = new(createCarRequest);
            Result<CarDetailResponse> result = await mediator.Send(command);
            return result.IsSuccess
                ? CreatedAtAction(nameof(Detail),new { id = result.Value.Id }, result.Value)
                : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(CreateCarRequest createCarRequest)
        {
            CreateCarCommand command = new(createCarRequest);
            Result<CarDetailResponse> result = await mediator.Send(command);
            return result.IsSuccess
                ? CreatedAtAction(nameof(Detail), new { id = result.Value.Id }, result.Value)
                : BadRequest();
        }

        [Route("{carId}/[action]")]
        [HttpPost]
        public async Task<IActionResult> Rent(string carId)
        {
            RentACarCommand command = new(new Application.DTOs.Persistence.Rental.RentACarRequest(carId, HttpContext.User.Identity.Name!));
            Result result = await mediator.Send(command);

            return result.IsSuccess 
                ? Ok()
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
