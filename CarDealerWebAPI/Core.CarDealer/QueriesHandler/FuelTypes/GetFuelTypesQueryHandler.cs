using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.FuelTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.FuelTypes
{
    public class GetFuelTypesQueryHandler : IRequestHandler<GetFuelTypesQuery, IEnumerable<FuelType>>
    {
        IRepositoryFuelType _repositoryFuelType;
        public GetFuelTypesQueryHandler(IRepositoryFuelType repositoryFuelType)
        {
            _repositoryFuelType = repositoryFuelType;

        }
        public async Task<IEnumerable<FuelType>> Handle(GetFuelTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryFuelType.GetFuelTypes();
        }
    }
}
