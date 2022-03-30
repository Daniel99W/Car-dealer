using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler
{
    public class GetCarsByFiltersQueryHandler : IRequestHandler<GetCarsByFiltersQuery,IEnumerable<Car>>
    {
        IRepositoryCar _repository;
        public GetCarsByFiltersQueryHandler(IRepositoryCar repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Car>> Handle(GetCarsByFiltersQuery request,CancellationToken cancellationToken)
        {
            return await _repository.GetCars(
                request.Page,
                request.CarsPerPage,
                request.Brand,
                request.CarType,
                request.Title,
                request.ProductionYear,
                request.MinPrice,
                request.MaxPrice,
                request.OrderBy
                );
        }
    }
}
