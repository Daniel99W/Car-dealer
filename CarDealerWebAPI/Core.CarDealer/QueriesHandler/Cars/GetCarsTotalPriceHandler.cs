using Core.CarDealer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.Cars
{
    public class GetCarsTotalPriceHandler : IRequestHandler<GetCarsTotalPriceQuery, int>
    {
        private IRepositoryCar _repositoryCar;
        public GetCarsTotalPriceHandler(IRepositoryCar repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }
        public async Task<int> Handle(GetCarsTotalPriceQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryCar.GetCarsTotalPrice();
        }
    }
}
