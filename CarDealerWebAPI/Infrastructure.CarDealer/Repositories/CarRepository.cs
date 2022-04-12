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
    public class CarRepository : Repository<Car>, IRepositoryCar
    {
        public CarRepository(AnnouncesContext announcesContext)
            : base(announcesContext)
        {

        }

        private IQueryable<Car> GetCarQuery()
        {
            return _announcesContext.Cars.
                 Join(_announcesContext.Users,
                 car => car.UserId,
                 user => user.Id,
                 (car, user) => new { car, user })
                 .Join(_announcesContext.Brands,
                 carUser => carUser.car.BrandId,
                 brand => brand.Id,
                 (carUser, brand) => new { carUser, brand })
                 .Join(_announcesContext.CarTypes,
                 carUserBrand => carUserBrand.carUser.car.CarTypeId,
                 carType => carType.Id,
                 (carUserBrand, carType) => new { carUserBrand, carType })
                 .Select(carUserBrandType => new Car()
                 {
                     Id = carUserBrandType.carUserBrand.carUser.car.Id,
                     CarNumber = carUserBrandType.carUserBrand.carUser.car.CarNumber,
                     ProductionYear = carUserBrandType.carUserBrand.carUser.car.ProductionYear,
                     Price = carUserBrandType.carUserBrand.carUser.car.Price,
                     SecondHand = carUserBrandType.carUserBrand.carUser.car.SecondHand,
                     AddingDate = carUserBrandType.carUserBrand.carUser.car.AddingDate,
                     User = carUserBrandType.carUserBrand.carUser.user,
                     UserId = carUserBrandType.carUserBrand.carUser.car.UserId,
                     Description = carUserBrandType.carUserBrand.carUser.car.Description,
                     Model = carUserBrandType.carUserBrand.carUser.car.Model,
                     CilindricCapacity = carUserBrandType.carUserBrand.carUser.car.CilindricCapacity,
                     Brand = carUserBrandType.carUserBrand.brand,
                     CarType = carUserBrandType.carType,
                 });
        }

        public async override Task<IEnumerable<Car>> GetItems()
        {
            return await GetCarQuery().ToListAsync();
        }

        public async Task<Car>? GetCarByUserId(int userId)
        {
            return await GetCarQuery()
               .Where(car => car.UserId == userId)
               .SingleOrDefaultAsync();
        }

        private Func<Car, int> orderByPrice = car => car.Price;

        public async Task<IEnumerable<Car>> GetCars(
            int page,
            int carsPerPage,
            string? brand,
            string? carType,
            string? title,
            int? productionYear,
            int? minPrice,
            int? maxPrice,
            bool? orderBy
            )
        {

            IQueryable<Car> query = GetCarQuery();

            List<Car> cars = new();

            if (minPrice != null && maxPrice != null)
                query = query.Where(car => car.Price >= minPrice && car.Price <= maxPrice);
            else
            {
                if (minPrice != null)
                    query = query.Where(car => car.Price >= minPrice);
                else if (maxPrice != null)
                    query = query.Where(car => car.Price <= maxPrice);
            }

            if (brand != null)
                query = query.Where(car => car.Brand.Name == brand);
            if (carType != null)
                query = query.Where(car => car.CarType.Name == carType);
            if (productionYear != null)
                query = query.Where(car => car.ProductionYear == productionYear);
            if(title != null)
                query = query.Where(car => car.Title.Contains(title));
            if (orderBy != null && orderBy == true)
            {
                cars = await query
                    .Paginate(page, carsPerPage)
                    .ToListAsync();
                cars = cars.OrderBy(car => orderByPrice(car)).ToList();
            }
            else if (orderBy != null)
            {
                cars = await query
                    .Paginate(page,carsPerPage)
                    .ToListAsync();
                cars = cars.OrderByDescending(car => orderByPrice(car)).ToList();
            }
            else
            {
                cars = await query
                    .Paginate(page, carsPerPage)
                    .ToListAsync();
            }

            cars = await query.ToListAsync();
            return cars;  
        }

        public override async Task<Car>? Read(int id)
        {
            return await _announcesContext.Cars
                .Where(car => car.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetCarsNumber()
        {
            return await GetCarQuery().CountAsync();
        }

        public async Task<int> GetCarsTotalPrice()
        {
            return await _announcesContext.Cars.SumAsync(car => car.Price);
        }

        public override Car Create(Car car)
        {
            return _announcesContext.Cars.Add(car).Entity;
        }



    }
}
