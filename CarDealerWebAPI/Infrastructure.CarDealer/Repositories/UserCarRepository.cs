using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Repositories
{
    public class UserCarRepository : Repository<UserCar>,IRepositoryUserCar
    {
        public UserCarRepository(AnnouncesContext announcesContext)
            :base(announcesContext)
        {

        }

        public async Task<IEnumerable<Car>> GetAllFavoriteCarsByUser(Guid userId)
        {
            return await _announcesContext.UserCars.Join(_announcesContext.Cars,
                userCar => userCar.Id,
                car => car.Id,
                (userCar, car) => new { userCar, car })
                .Where(userCar => userCar.userCar.UserId == userId)
                .Select(userCar => new Car
                {
                    Id = userCar.car.Id,
                    Title = userCar.car.Title,
                    BrandId = userCar.car.BrandId,
                    CarNumber = userCar.car.CarNumber,
                    CarTypeId = userCar.car.CarTypeId,
                })
                .ToListAsync();

        }
    }
}
