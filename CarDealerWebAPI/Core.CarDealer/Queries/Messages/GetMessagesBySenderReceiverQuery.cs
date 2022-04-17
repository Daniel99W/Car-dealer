using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.Messages
{
    public class GetMessagesBySenderReceiverQuery : IRequest<IEnumerable<Message>>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
