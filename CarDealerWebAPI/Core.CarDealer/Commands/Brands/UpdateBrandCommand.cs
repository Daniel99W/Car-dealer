using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Brands
{
    public class UpdateBrandCommand : IRequest<Brand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
    }
}
