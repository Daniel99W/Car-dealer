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
    public class GetCarByUserIdQueryHandler : IRequestHandler<GetCarByUserIdQuery, Car>
    {
        private IRepositoryCar _repositoryCar;

        public GetCarByUserIdQueryHandler(IRepositoryCar repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }
        public Task<Car> Handle(GetCarByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _repositoryCar.GetCarByUserId(request.userId);
        }
    }
}
