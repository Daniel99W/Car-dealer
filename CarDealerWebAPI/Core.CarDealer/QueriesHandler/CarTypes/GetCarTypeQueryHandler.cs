using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.CarTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.CarTypes
{
    public class GetCarTypeQueryHandler : IRequestHandler<GetCarTypeQuery, CarType?>
    {
        private IRepositoryCarType _repositoryCarType;
        public GetCarTypeQueryHandler(IRepositoryCarType repositoryCarType)
        {
            _repositoryCarType = repositoryCarType;
        }
        public async Task<CarType?> Handle(GetCarTypeQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryCarType.Read(request.Id);
        }
    }
}
