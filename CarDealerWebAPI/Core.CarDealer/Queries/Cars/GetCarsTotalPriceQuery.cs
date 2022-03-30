using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.Cars
{
    public class GetCarsTotalPriceQuery : IRequest<int>
    {
    }
}
