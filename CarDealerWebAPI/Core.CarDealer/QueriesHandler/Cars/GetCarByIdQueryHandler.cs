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
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Car>
    {
        IRepositoryCar _repositoryCar;
        public GetCarByIdQueryHandler(IRepositoryCar repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }
        public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryCar.Read(request.Id);
        }
    }
}
