using Core.CarDealer.Commands;
using Core.CarDealer.Models;
using Infrastructure.CarDealer.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IMediator _mediator;
        private CarRepository _carRepository;
        public CarsController(IMediator mediator,CarRepository carRepository)
        {
            _mediator = mediator;
            _carRepository = carRepository;
        }

        // GET: api/<CarsController>
        [HttpGet("{id")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            Car? car = await _carRepository.Read(id);

            if (car != null)
                return new ActionResult<Car>(car);

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(string carNumber)
        {
            var result = await _mediator.Send(new CreateCarCommand
            {
                CarNumber = carNumber
            });


        }





    }
}
