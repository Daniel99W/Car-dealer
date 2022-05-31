using AutoMapper;
using Core.CarDealer.Commands.Users;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

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
       public async Task<ActionResult<UserDTO>> UpdateUser(UserDTO userDTO)
       {
            return await _mediator.Send(_mapper.Map<UpdateUserCommand>(userDTO));
       }

       [HttpPost]
       public async Task<ActionResult> CreateUser(CreateUserDTO userDTO)
       {
            await _mediator.Send(_mapper.Map<CreateUserCommand>(userDTO));
            return Ok();
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<GetUserDTO>> GetUserById(Guid id)
       {
            User user = await _mediator.Send(new GetUserByIdQuery
            {
                Id = id
            });

            return _mapper.Map<GetUserDTO>(user);
       }

       [HttpPost]
       public async Task<ActionResult> SignUp(SignUpUserDTO user)
       {
            await _mediator.Send(new SignUpUserCommand()
            {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                SecondName = user.SecondName
            });
            return Ok();
       }

       [HttpPost]
       public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            JwtSecurityToken? jwt = await _mediator.Send(new LoginUserCommand()
            {
                Email = loginDTO.Email,
                Password = loginDTO.Password
            });
            if (jwt == null)
                return NotFound();

            var tokenEncoded = new JwtSecurityTokenHandler().WriteToken(jwt);
            Cookie cookie = new("token", tokenEncoded)
            {
                Expires = jwt.ValidTo
            };
            return Ok(cookie);
        }
       

       


        
        

    }
}
