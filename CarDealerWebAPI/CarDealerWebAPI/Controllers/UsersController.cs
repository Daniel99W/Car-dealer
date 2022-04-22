using AutoMapper;
using Core.CarDealer.Commands.Users;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public UsersController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

       [HttpPost]
       public async Task<ActionResult> CreateUser(CreateUserDTO userDTO)
       {
            await _mediator.Send(_mapper.Map<CreateUserCommand>(userDTO));
            return Ok();
       }

       [HttpGet("id")]
       public async Task<ActionResult<GetUserDTO>> GetUserById(Guid guid)
       {
            User user = await _mediator.Send(new GetUserByIdQuery
            {
                Id = guid
            });

            return _mapper.Map<GetUserDTO>(user);
       }

       


        
        

    }
}
