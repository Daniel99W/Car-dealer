using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.Messages
{
    public class GetMessageByUserIdQuery : IRequest<Message>
    {
        public int userId { get; set; }
    }
}
