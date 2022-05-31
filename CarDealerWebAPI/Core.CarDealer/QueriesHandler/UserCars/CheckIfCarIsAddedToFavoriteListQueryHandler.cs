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
    public class CheckIfCarIsAddedToFavoriteListQueryHandler :
        IRequestHandler<CheckIfCarIsAddedToFavoriteListQuery, bool>
    {
        private IRepositoryUserCar _repositoryUserCar;

        public CheckIfCarIsAddedToFavoriteListQueryHandler(IRepositoryUserCar repositoryUserCar)
        {
            this._repositoryUserCar = repositoryUserCar;
        }
        public Task<bool> Handle(CheckIfCarIsAddedToFavoriteListQuery request, CancellationToken cancellationToken)
        {
            return _repositoryUserCar.CheckIfCarIsAddedToFavorite(request.UserId, request.CarId);
        }
    }
}
