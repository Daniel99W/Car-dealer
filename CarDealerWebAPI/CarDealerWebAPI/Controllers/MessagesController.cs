
using Core.CarDealer.Commands.Messages;
using Core.CarDealer.CommandsHandler.Messages;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;


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
   
        [HttpPost]
        public async Task<ActionResult<Message>> SendMessage(MessageDTO messageDTO)
        {
            return await _mediator.Send(new CreateUnitOfWorkMessagesCommand
            {
                Content = messageDTO.Content,
                UserId = messageDTO.senderId,
                Subject = messageDTO.Subject,
                ReceiverId = messageDTO.receiverId
            });
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(GetMessagesDTO getMessagesDTO)
        {
            return new ActionResult<IEnumerable<Message>>(
                await _mediator.Send(new GetMessagesBySenderReceiverQuery
            {
                ReceiverId = getMessagesDTO.ReceiverId,
                SenderId = getMessagesDTO.SenderId
            }));
        }


        
    }
}
