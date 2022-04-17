using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries
{
    public  class GetCarByUserIdQuery : IRequest<Car>
    {
        public Guid userId { get; set; }
    }
}
