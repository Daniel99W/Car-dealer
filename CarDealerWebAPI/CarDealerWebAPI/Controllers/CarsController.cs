using Core.CarDealer.Commands;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using Infrastructure.CarDealer.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IMediator _mediator;
        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Car>> GetCarByUserId(int userId)
        {
            Car car = await _mediator.Send(new GetCarByUserIdQuery
            {
                userId = userId
            });

            if (car != null)
                return new ActionResult<Car>(car);

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            string? brand = Request.Query["brand"];
            string? carType = Request.Query["carType"];
            int? productionYear = Convert.ToInt32(Request.Query["prodYear"]);
            int? minPrice = Convert.ToInt32(Request.Query["minPrice"]);
            int? maxPrice = Convert.ToInt32(Request.Query["maxPrice"]);

            IEnumerable<Car> cars = await _mediator.Send(new GetCarsByBrandTypePriceYear
            {
                Brand = brand,
                CarType = carType,
                ProductionYear = productionYear,
                MinPrice = minPrice,
                MaxPrice = maxPrice
            });

            return new ActionResult<IEnumerable<Car>>(cars);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            return await _mediator.Send(new CreateCarCommand
            {
                Id = car.Id,
                CarNumber = car.CarNumber,
                ProductionYear = car.ProductionYear,
                Price = car.Price,
                SecondHand = car.SecondHand,
                AddingDate = car.AddingDate,
                UserId = car.UserId,
                FuelType = car.FuelType,
                Description = car.Description,
                Model = car.Model,
                CilindricCapacity = car.CilindricCapacity,
                BrandId = car.BrandId,
                CarTypeId = car.CarTypeId
            });

        }

        [HttpGet]
        public async Task<ActionResult<Car>> Get(int id)
        {
            return await _mediator.Send(new GetCarByIdQuery
            {
                 Id = id
            });
        }


        





    }
}
