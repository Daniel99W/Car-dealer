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
    }
}
