using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.UserCars;
using MediatR;

namespace Core.CarDealer.QueriesHandler.UserCars
{
    public class GetUserFavoriteCarsByUserIdQueryHandler 
        : IRequestHandler<GetUserFavoriteCarsByUserIdQuery,IEnumerable<Car>>
    {
        private IRepositoryUserCar _repositoryUserCar;
        public GetUserFavoriteCarsByUserIdQueryHandler(IRepositoryUserCar repositoryUserCar)
        {
            _repositoryUserCar = repositoryUserCar;
        }

        public async Task<IEnumerable<Car>> Handle(
            GetUserFavoriteCarsByUserIdQuery request, 
            CancellationToken cancellationToken)
        {
            return await _repositoryUserCar.GetAllFavoriteCarsByUser(request.UserId);
        }
    }
}
