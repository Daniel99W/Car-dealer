using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.CarTypes
{
    public class UpdateCarTypeCommand : IRequest<CarType>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
