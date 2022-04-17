using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries
{
    public  class GetCarsByFiltersQuery: IRequest<PaginatedDTO<Car>>
    {
        public int Page { get; set; }
        public int CarsPerPage { get; set; }
        public string? CarType { get; set; }
        public string? Brand { get; set; }

        public string? Title { get; set; }

        public int? ProductionYear { get; set; }
        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public bool? OrderBy { get; set; }

    }
}
