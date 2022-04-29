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
    }
}
