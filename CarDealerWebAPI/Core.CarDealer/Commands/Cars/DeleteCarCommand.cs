using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Cars
{
    public class DeleteCarCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
