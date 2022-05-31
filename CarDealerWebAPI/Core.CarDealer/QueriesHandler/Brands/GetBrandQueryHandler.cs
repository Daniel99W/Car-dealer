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
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, Brand>
    {
        private IRepositoryBrand _repositoryBrand;

        public GetBrandQueryHandler(IRepositoryBrand repositoryBrand)
        {
            _repositoryBrand = repositoryBrand;
        }
        public async Task<Brand?> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryBrand.Read(request.Id);
        }
    }
}
