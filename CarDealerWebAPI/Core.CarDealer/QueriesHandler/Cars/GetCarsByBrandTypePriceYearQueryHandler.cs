﻿using Core.CarDealer.Interfaces;
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
    public class GetCarsByBrandTypePriceYearQueryHandler : IRequestHandler<GetCarsByBrandTypePriceYearQuery,IEnumerable<Car>>
    {
        IRepositoryCar _repository;
        public GetCarsByBrandTypePriceYearQueryHandler(IRepositoryCar repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Car>> Handle(GetCarsByBrandTypePriceYearQuery request,CancellationToken cancellationToken)
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