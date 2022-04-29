using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.CarTypes;
using MediatR;

namespace Core.CarDealer.QueriesHandler.CarTypes
{
    public class GetCarTypesQueryHandler : IRequestHandler<GetCarTypesQuery, IEnumerable<CarType>>
    {
        private IRepositoryCarType _repositoryCarType;
        public GetCarTypesQueryHandler(IRepositoryCarType repositoryCarType)
        {
            _repositoryCarType = repositoryCarType;
        }
        public async Task<IEnumerable<CarType>> Handle(GetCarTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryCarType.GetCarTypes();
        }
    }
}
