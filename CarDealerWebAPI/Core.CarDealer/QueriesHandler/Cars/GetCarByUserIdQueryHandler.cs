using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using MediatR;

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
