using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.CarTypes
{
    public class GetCarTypeQuery : IRequest<CarType?>
    {
        public Guid Id { get; set; }
    }
}
