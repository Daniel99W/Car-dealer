
using CarDealerWebAPI.HubConfig;
using Core.CarDealer.Commands.Mesages;
using Core.CarDealer.CommandsHandler.Messages;
using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CarDealerWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private IMediator _mediator;

        public MessagesController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> SendMessage(MessageDTO messageDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _mediator.Send(new CreateUnitOfWorkMessagesCommand
            {
                Content = messageDTO.Content,
                UserId = messageDTO.SenderId,
                Subject = messageDTO.Subject,
                ReceiverId = messageDTO.ReceiverId
            });
            return Ok();
        }

        [HttpGet("{receiverId}")]
        public async Task<ActionResult<IEnumerable<GetMessageDTO>>> GetMessages(Guid receiverId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return new ActionResult<IEnumerable<GetMessageDTO>>(
                await _mediator.Send(new GetMessagesByReceiverIdQuery()
                {
                    ReceiverId = receiverId
                }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMessageDTO>> GetMessage(Guid id)
        {
            return new ActionResult<GetMessageDTO>(
                await _mediator.Send(new GetMessageByIdQuery()
                {
                    Id = id
                }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteMessageCommand()
            {
                Id = id
            });

            return Ok();
        }


        
    }
}
