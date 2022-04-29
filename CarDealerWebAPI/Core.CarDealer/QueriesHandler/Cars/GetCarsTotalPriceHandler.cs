using Core.CarDealer.Interfaces;
using MediatR;

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
