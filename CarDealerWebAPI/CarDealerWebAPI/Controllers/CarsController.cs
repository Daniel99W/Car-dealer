using AutoMapper;
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
        private MapperConfiguration _mapperConfiguration;
        public CarsController(IMediator mediator,MapperConfiguration mapperConfiguration)
        {
            _mediator = mediator;
            _mapperConfiguration = mapperConfiguration;
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

        [HttpPost("{page}")]
        public async Task<ActionResult<PaginatedDTO<Car>>> GetCars(int page,CarParametersQueryDTO carParametersQuery)
        { 
          
            return await _mediator.Send();
        }

        [HttpPost]
        public async Task<ActionResult> PostCar([FromForm] CreateCarDTO createCarDTO)
        {

            Car car = await _mediator.Send(new CreateCarCommand
            {
                CarNumber = createCarDTO.CarDTO.CarNumber,
                ProductionYear = createCarDTO.CarDTO.ProductionYear,
                Price = createCarDTO.CarDTO.Price,
                Title = createCarDTO.CarDTO.Title,
                SecondHand = createCarDTO.CarDTO.SecondHand,
                UserId = createCarDTO.CarDTO.UserId,
                FuelType = createCarDTO.CarDTO.FuelType,
                Description = createCarDTO.CarDTO.Description,
                Model = createCarDTO.CarDTO.Model,
                CilindricCapacity = createCarDTO.CarDTO.CilindricCapacity,
                BrandId = createCarDTO.CarDTO.BrandId,
                CarTypeId = createCarDTO.CarDTO.CarTypeId,
                Images = createCarDTO.Images
            });

            foreach (IFormFile image in createCarDTO.Images)
                await _mediator.Send(new CreateImageCommand()
                {
                    CarId = car.Id,
                    FormFile = image
                });

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
