using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Brands
{
    public class CreateBrandCommand : IRequest<Brand>
    {

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
