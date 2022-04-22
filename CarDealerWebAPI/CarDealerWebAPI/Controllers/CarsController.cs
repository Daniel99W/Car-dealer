using AutoMapper;
using Core.CarDealer.Commands;
using Core.CarDealer.Commands.Cars;
using Core.CarDealer.Commands.Images;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using Core.CarDealer.QueriesHandler.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;
        public CarsController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Car>> GetCarByUserId(Guid userId)
        {
            Car? car = await _mediator.Send(new GetCarByUserIdQuery
            {
                userId = userId
            });

            if (car == null)
                return NotFound();

            return car;
        }

        [HttpPost]
        public async Task<ActionResult<PaginatedDTO<Car>>> GetCars(CarParametersQueryDTO carParametersQuery)
        {
            return await _mediator.Send(_mapper.Map<GetCarsByFiltersQuery>(carParametersQuery));
        }

        [HttpPost]
        public async Task<ActionResult> PostCar([FromForm] CreateCarDTO createCarDTO)
        {
            Car car = await _mediator.Send(_mapper.Map<CreateCarCommand>(createCarDTO));

            foreach(IFormFile file in createCarDTO.Images)
            {
                await _mediator.Send(new CreateImageCommand
                {
                    CarId = car.Id,
                    FormFile = file
                });
            }
         
            return Ok("The car has been created with success!");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(Guid id)
        {
            Car? car =  await _mediator.Send(new GetCarByIdQuery
            {
                 Id = id
            });

            if (car == null)
                return NotFound();
            return car;
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetCarsTotalPrice()
        {
            return await _mediator.Send(new GetCarsTotalPriceQuery());
        }

        [HttpPost]
        public async Task<ActionResult> Update(Car car)
        {
           await _mediator.Send(_mapper.Map<UpdateCarCommand>(car));
           return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            await _mediator.Send(new DeleteCarCommand()
            {
                Id = id
            });
            return Ok();
        }




        





    }
}
