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
    public class RemoveCarFromUserFavoriteListQueryHandler
        : IRequestHandler<RemoveCarFromUserFavoriteListQuery, Unit>
    {
        private IRepositoryUserCar _repositoryUserCar;

        public RemoveCarFromUserFavoriteListQueryHandler(IRepositoryUserCar repositoryUserCar)
        {
            _repositoryUserCar = repositoryUserCar;
        }
        public async Task<Unit> Handle(RemoveCarFromUserFavoriteListQuery request, CancellationToken cancellationToken)
        {
            await _repositoryUserCar.RemoveCarFromFavoriteList(request.CarId, request.UserId);
            return await Task.FromResult(Unit.Value);
        }
    }
}
