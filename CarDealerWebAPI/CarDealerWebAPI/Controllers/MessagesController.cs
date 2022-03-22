using Core.CarDealer.Commands.Messages;
using Core.CarDealer.CommandsHandler.Messages;
using Core.CarDealer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<Message> Get(int id)
        //{
        //    return await _mediator.Send(new CreateMessageCommandHandler
        //    {
                
        //    })
        //}

        [HttpPost]
        public async Task<Message> Post(Message message)
        {
            return await _mediator.Send(new CreateMessageCommand
            {
                Content = message.Content,
                UserId = (int)message.UserId,
                Subject = message.Subject
            });
        }
        
    }
}
