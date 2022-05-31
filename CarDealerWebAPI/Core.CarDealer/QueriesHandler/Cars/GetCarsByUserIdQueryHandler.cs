using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.Cars
{
    public class GetCarsByUserIdQueryHandler : IRequestHandler<GetCarsByUserIdQuery, IEnumerable<Car>>
    {
        private IRepositoryCar _repositoryCar;
        public GetCarsByUserIdQueryHandler(IRepositoryCar repositoryCar)
        {
            this._repositoryCar = repositoryCar;
        }

        public async Task<IEnumerable<Car>> Handle(GetCarsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryCar.GetCarsByUserId(request.UserId);
        }
    }
}
