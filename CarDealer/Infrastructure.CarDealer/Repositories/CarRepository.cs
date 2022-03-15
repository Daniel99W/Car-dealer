using CarDealer.Models;
using Core.CarDealer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private AnnouncesContext announcesContext;
        public CarRepository(AnnouncesContext announcesContext)
        {
            this.announcesContext = announcesContext;
        }

        public void Create(Car obj)
        {
            announcesContext.Cars.Add(obj);
            announcesContext.SaveChanges();
        }

        public void Delete(Car obj)
        {
            announcesContext.Cars.Remove(obj);
            announcesContext.SaveChanges();
        }

        public async Task<Car> Read(int id)
        {
            return await announcesContext.Cars.FindAsync(id);
        }

        public void Update(Car obj)
        {
            announcesContext.Cars.Update(obj);
            announcesContext.SaveChanges();
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
           return await announcesContext.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByUserId(int userId)
        {
            return await announcesContext.Cars
                .Join(announcesContext.Users,
                car => car.UserId,
                user => user.Id,
                (car, user) => new { car, user })
                .Where(carUser => carUser.user.Id == userId)
                .Select(carUser => new Car()
                {
                    Id = carUser.car.Id,
                    CarNumber = carUser.car.CarNumber,
                    ProductionYear = carUser.car.ProductionYear,
                    Price = carUser.car.Price,
                    SecondHand = carUser.car.SecondHand,
                    AddingDate = carUser.car.AddingDate,
                    User = carUser.user,
                    Description = carUser.car.Description,
                    CilindricCapacity = carUser.car.CilindricCapacity,
                    Model = carUser.car.Model,
                    UserId = carUser.car.UserId
                })
                .SingleOrDefaultAsync();
        }
    }
}
