using Core.CarDealer.Commands.CarTypes;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.CarTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private IMediator _mediator;
        public CarTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddCarType(CreateCarTypeDTO createCarTypeDTO)
        {
            await _mediator.Send(new CreateCarTypeCommand()
            {
                Name = createCarTypeDTO.Name,
            });
            return Ok(200);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarType>>> GetCarTypes()
        {
            return new ActionResult<IEnumerable<CarType>>(await _mediator.Send(new GetCarTypesQuery()));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarType(Guid id)
        {
            await _mediator.Send(new DeleteCarTypeCommand()
            {
                Id = id
            });
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CarType>> UpdateCarType(CarType carType)
        {
            return await _mediator.Send(new UpdateCarTypeCommand()
            {
                Id = carType.Id,
                Name = carType.Name,
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> GetCarType(Guid id)
        {
            CarType ? carType =  await _mediator.Send(new GetCarTypeQuery()
            {
                Id = id
            });

            if (carType == null)
                return NotFound();

            return carType;
        }


    }
}
