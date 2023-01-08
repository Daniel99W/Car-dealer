using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Mesages
{
    public class DeleteMessageCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
