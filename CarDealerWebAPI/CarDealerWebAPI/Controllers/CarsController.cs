using Core.CarDealer.Commands;
using Core.CarDealer.Commands.Cars;
using Core.CarDealer.Commands.Images;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using Core.CarDealer.QueriesHandler;
using Core.CarDealer.QueriesHandler.Cars;
using Infrastructure.CarDealer.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

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
            Car? car = await _mediator.Send(new GetCarByUserIdQuery
            {
                userId = userId
            });

            if (car == null)
                return NotFound();

            return car;
        }

        [HttpPost("{page}")]
        public async Task<ActionResult<PaginatedDTO<Car>>> GetCars(int page,CarParametersQueryDTO carParametersQuery)
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

            PaginatedDTO<Car> paginatedDTO = new();

            paginatedDTO.CurrentPage = page;
            paginatedDTO.TotalPages =
                Convert.ToInt32(Math.Ceiling((double)cars.Count() / carParametersQuery.CarsPerPage));

            if (paginatedDTO.PrevPage <= 0)
                paginatedDTO.PrevPage = null;
            if (paginatedDTO.NextPage >= paginatedDTO.TotalPages)
                paginatedDTO.NextPage = null;

            return paginatedDTO;
        }

        [HttpPost]
        public async Task<ActionResult> PostCar()
        {
            IEnumerable<IFormFile> images = HttpContext.Request.Form.Files;
            string jsonCar = HttpContext.Request.Form["car"];

            CreateCarDTO createCarDTO = JsonSerializer.Deserialize<CreateCarDTO>(jsonCar);

            Car car = await _mediator.Send(new CreateCarCommand
            {
                CarNumber = createCarDTO.CarNumber,
                ProductionYear = createCarDTO.ProductionYear,
                Price = createCarDTO.Price,
                Title = createCarDTO.Title,
                SecondHand = createCarDTO.SecondHand,
                UserId = createCarDTO.UserId,
                FuelType = createCarDTO.FuelType,
                Description = createCarDTO.Description,
                Model = createCarDTO.Model,
                CilindricCapacity = createCarDTO.CilindricCapacity,
                BrandId = createCarDTO.BrandId,
                CarTypeId = createCarDTO.CarTypeId,
                Images = images
            });

            foreach (IFormFile image in images)
                await _mediator.Send(new CreateImageCommand()
                {
                    CarId = car.Id,
                    FormFile = image
                });

            return Ok("The car has been created with success!");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
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
            await _mediator.Send(new UpdateCarCommand()
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

           return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new DeleteCarCommand()
            {
                Id = id
            });

            return Ok();
        }




        





    }
}
