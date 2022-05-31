using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
    public interface IRepositoryUserCar : IRepository<UserCar>
    {
        public Task<IEnumerable<Car>> GetAllFavoriteCarsByUser(Guid userId);

        public Task<bool> CheckIfCarIsAddedToFavorite(Guid userId,Guid carId);

        public Task RemoveCarFromFavoriteList(Guid carId,Guid userId);

        public Task<int> GetCarsNumberInFavoriteList(Guid userId);
    }
}
