using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.CarTypes
{
    public class GetCarTypesQuery : IRequest<IEnumerable<CarType>>
    {
    }
}
