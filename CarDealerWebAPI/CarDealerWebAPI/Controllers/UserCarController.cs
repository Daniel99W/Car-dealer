using AutoMapper;
using Core.CarDealer.Commands.UserCars;
using Core.CarDealer.DTO;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.UserCars;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserCarController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;
        public UserCarController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddCarUserFavoriteList(FavoriteDTO favoriteDTO)
        {

            await _mediator.Send(_mapper.Map<CreateUserCarCommand>(favoriteDTO));
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetUserCarsByUserId(Guid userId)
        {
            return new ActionResult<IEnumerable<Car>>(await _mediator.Send(new GetUserFavoriteCarByUserIdQuery
            {
                UserId = userId
            }));
        }
    }
}
