using Core.CarDealer.Commands.FuelTypes;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.FuelTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private IMediator _mediator;
        public FuelTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddFuelType(CreateFuelTypeDTO createFuelTypeDTO)
        {
            await _mediator.Send(new CreateFuelTypeCommand()
            {
                Name = createFuelTypeDTO.Name,
            });
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelType>>> GetFuelTypes()
        {
            return new ActionResult<IEnumerable<FuelType>>(await _mediator.Send(new GetFuelTypesQuery()));
        }

    }
}
