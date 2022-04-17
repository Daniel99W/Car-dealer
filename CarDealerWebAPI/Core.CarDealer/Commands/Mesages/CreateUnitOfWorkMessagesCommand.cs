using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Messages
{
    public class CreateUnitOfWorkMessagesCommand : IRequest<Message>
    {
        public Guid UserId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Guid ReceiverId { get; set; }
    }
}
