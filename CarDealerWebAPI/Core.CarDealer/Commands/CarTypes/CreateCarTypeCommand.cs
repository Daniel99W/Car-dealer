using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.CarTypes
{
    public class CreateCarTypeCommand : IRequest<CarType>
    {
        public string? Name { get; set; }
    }
}
