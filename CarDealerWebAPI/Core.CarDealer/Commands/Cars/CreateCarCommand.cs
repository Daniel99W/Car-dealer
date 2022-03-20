using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands
{
    public class CreateCarCommand : IRequest<bool>
    {
        public string CarNumber { get; set; }

    }
}
