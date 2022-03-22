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
    public class GetCarsByBrandTypePriceYearHandler : IRequestHandler<GetCarsByBrandTypePriceYear,IEnumerable<Car>>
    {
        IRepositoryCar _repository;
        public GetCarsByBrandTypePriceYearHandler(IRepositoryCar repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Car>> Handle(GetCarsByBrandTypePriceYear request,CancellationToken cancellationToken)
        {
            return await _repository.GetCars(
                request.Brand,
                request.CarType,
                request.ProductionYear,
                request.MinPrice,
                request.MaxPrice);
        }
    }
}
