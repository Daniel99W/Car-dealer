using CarDealer.Models;
using Core.CarDealer.Interfaces;
using Infrastructure.CarDealer.Queries;
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

        public async Task<IEnumerable<Car>> GetAllCars(
            bool? secondHand,
            string? fuelType,
            string? brand,
            string? carType)
        {

            IQueryable<Car> query = CarQueries.GetCarQuery(announcesContext);

            if (secondHand != null)
                query = query.Where(car => car.SecondHand == secondHand);
            if (fuelType != null)
                query = query.Where(car => car.FuelTypeNavigation.Name == fuelType);
            if (brand != null)
                query = query.Where(car => car.Brand.Name == brand);
            if (carType != null)
                query = query.Where(car => car.CarType.Name == carType);

            return await query.ToListAsync();
        }

        public async Task<Car> GetCarByUserId(int userId)
        {
            return await CarQueries.GetCarQuery(announcesContext)
                .Where(car => car.UserId == userId)
                .SingleOrDefaultAsync();
        }
    }
}
