using Core.CarDealer.Interfaces;
using Core.CarDealer.Queries.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.Cars
{
    public class GetCarsNumberQueryHandler : IRequestHandler<GetCarsNumberQuery, int>
    {
        private IRepositoryCar _repositoryCar;

        public GetCarsNumberQueryHandler(IRepositoryCar repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }
        public async Task<int> Handle(GetCarsNumberQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryCar.GetCarsNumber(request.UserId);
        }
    }
}
