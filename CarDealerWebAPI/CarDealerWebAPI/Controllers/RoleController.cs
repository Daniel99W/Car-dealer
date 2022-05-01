using Core.CarDealer.Commands.Roles;
using Core.CarDealer.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost] 
        public async Task<ActionResult> Create(CreateRoleDTO createRoleDTO)
        {
            await _mediator.Send(new CreateRoleCommand()
            {
                RoleName = createRoleDTO.RoleName,
            });
            return Ok();
        }
    }
}
