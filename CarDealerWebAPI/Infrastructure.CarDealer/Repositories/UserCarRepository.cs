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

        public async Task<bool> CheckIfCarIsAddedToFavorite(Guid userId,Guid carId)
        {
            UserCar ? userCar = await 
            _announcesContext.UserCars.Where(
            userCar => 
            (userCar.UserId == userId) &&
            (userCar.CarId == carId)).SingleOrDefaultAsync();

            if (userCar == null)
                return false;
            return true;
        }

        public async Task<IEnumerable<Car>> GetAllFavoriteCarsByUser(Guid userId)
        {
            return await _announcesContext.UserCars.Join(_announcesContext.Cars,
                userCar => userCar.CarId,
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
                    Price = userCar.car.Price,
                })
                .ToListAsync();

        }

        public async Task RemoveCarFromFavoriteList(Guid carId, Guid userId)
        {
            UserCar userCar = await _announcesContext.UserCars
                .Where(userCar => userCar.CarId == carId && userCar.UserId == userId)
                .SingleAsync();

            _announcesContext.UserCars.Remove(userCar);
            await _announcesContext.SaveChangesAsync();
        }
    }
}
