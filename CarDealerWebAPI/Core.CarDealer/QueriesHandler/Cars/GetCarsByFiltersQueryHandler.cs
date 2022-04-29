using Core.CarDealer.DTO;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries;
using MediatR;

namespace Core.CarDealer.QueriesHandler
{
    public class GetCarsByFiltersQueryHandler : IRequestHandler<GetCarsByFiltersQuery,PaginatedDTO<Car>>
    {
        IRepositoryCar _repository;
        public GetCarsByFiltersQueryHandler(IRepositoryCar repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<Car>> Handle(GetCarsByFiltersQuery request,CancellationToken cancellationToken)
        {
            return await _repository.GetCars(
                request.Page,
                request.CarsPerPage,
                request.Brand,
                request.CarType,
                request.Title,
                request.ProductionYear,
                request.MinPrice,
                request.MaxPrice,
                request.OrderBy
                );
        }
    }
}
