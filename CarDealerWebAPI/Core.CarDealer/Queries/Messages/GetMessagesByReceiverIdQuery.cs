using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.Messages
{
    public class GetMessagesByReceiverIdQuery : IRequest<IEnumerable<GetMessageDTO>>
    {
        public Guid ReceiverId { get; set; }
    }
}
