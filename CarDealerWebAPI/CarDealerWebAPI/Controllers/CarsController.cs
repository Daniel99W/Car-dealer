using Core.CarDealer.Commands;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using Core.CarDealer.QueriesHandler.Cars;
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

        [HttpPost("{page}")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars(int page,CarParametersQueryDTO carParametersQuery)
        { 
          
            IEnumerable<Car> cars = await _mediator.Send(new GetCarsByFiltersQuery
            {
                Page = page,
                CarsPerPage = carParametersQuery.CarsPerPage,
                Brand = carParametersQuery.Brand,
                CarType = carParametersQuery.CarType,
                Title = carParametersQuery.Title,
                ProductionYear = carParametersQuery.ProductionYear,
                MinPrice = carParametersQuery.MinPrice,
                MaxPrice = carParametersQuery.MaxPrice,
                OrderBy = carParametersQuery.OrderBy
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
                Title = car.Title,
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            return await _mediator.Send(new GetCarByIdQuery
            {
                 Id = id
            });
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetCarsTotalPrice()
        {
            return await _mediator.Send(new GetCarsTotalPriceQuery());
        }


        





    }
}
