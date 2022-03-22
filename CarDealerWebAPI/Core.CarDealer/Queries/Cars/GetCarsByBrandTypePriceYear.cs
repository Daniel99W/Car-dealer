using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries
{
    public  class GetCarsByBrandTypePriceYear : IRequest<IEnumerable<Car>>
    {
        public string? CarType { get; set; }
        public string? Brand { get; set; }

        public int? ProductionYear { get; set; }
        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

    }
}
