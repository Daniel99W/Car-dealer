using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Brands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.Brands
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IEnumerable<Brand>>
    {
        private IRepositoryBrand _repositoryBrand;
        public GetBrandsQueryHandler(IRepositoryBrand repositoryBrand)
        {
            _repositoryBrand = repositoryBrand;
        }
        public async Task<IEnumerable<Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryBrand.GetBrandsAsync();
        }
    }
}
