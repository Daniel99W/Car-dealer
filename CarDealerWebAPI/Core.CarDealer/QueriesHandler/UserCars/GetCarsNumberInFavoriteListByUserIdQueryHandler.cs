using Core.CarDealer.Interfaces;
using Core.CarDealer.Queries.UserCars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.UserCars
{
    public class GetCarsNumberInFavoriteListByUserIdQueryHandler
        : IRequestHandler<GetCarsNumberInFavoriteListByUserIdQuery, int>
    {
        private IRepositoryUserCar _repositoryUserCars;

        public GetCarsNumberInFavoriteListByUserIdQueryHandler(IRepositoryUserCar repositoryUserCar)
        {
            _repositoryUserCars = repositoryUserCar;
        }

        public async Task<int> Handle(GetCarsNumberInFavoriteListByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryUserCars.GetCarsNumberInFavoriteList(request.UserId);
        }
    }
}
