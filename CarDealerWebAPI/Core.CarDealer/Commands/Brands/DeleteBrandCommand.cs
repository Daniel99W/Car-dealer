using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Brands
{
    public  class DeleteBrandCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
