using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.UserCars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.UserCars
{
    public class GetUserFavoriteCarByUserIdQueryHandler : IRequestHandler<GetUserFavoriteCarByUserIdQuery,IEnumerable<Car>>
    {
        private IRepositoryUserCar _repositoryUserCar;
        public GetUserFavoriteCarByUserIdQueryHandler(IRepositoryUserCar repositoryUserCar)
        {
            _repositoryUserCar = repositoryUserCar;
        }

        public async Task<IEnumerable<Car>> Handle(GetUserFavoriteCarByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryUserCar.GetAllFavoriteCarsByUser(request.UserId);
        }
    }
}
