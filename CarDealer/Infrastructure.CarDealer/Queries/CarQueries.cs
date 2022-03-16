using CarDealer.Models;
using Core.CarDealer.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.CarDealer.Queries
{
    public class CarQueries
    {
        public static IQueryable<Car> GetCarQuery(AnnouncesContext announcesContext)
        {
            return announcesContext.Cars
                 .Join(announcesContext.Users,
                 car => car.UserId,
                 user => user.Id,
                 (car, user) => new {car,
                     user = new UserResultModel()
                     {
                        Id = user.Id,
                        Name = user.Name,
                        SecondName = user.SecondName,
                        Rol = user.Rol,
                        RolId = user.RolId
                     }
                 })
                 .Join(announcesContext.FuelTypes,
                 carUser => carUser.car.FuelType,
                 fuelType => fuelType.Id,
                 (carUser, fuelType) => new { carUser, fuelType })
                 .Join(announcesContext.Brands,
                 carUserFuel => carUserFuel.carUser.car.BrandId,
                 brand => brand.Id,
                 (carUserFuel, brand) => new { carUserFuel, brand })
                 .Join(announcesContext.CarTypes,
                 carUserFuelType => carUserFuelType.carUserFuel.carUser.car.CarTypeId,
                 carType => carType.Id,
                 (carUserFuelTypeBr, carType) => new Car()
                 {
                     Id = carUserFuelTypeBr.carUserFuel.carUser.car.Id,
                     CarNumber = carUserFuelTypeBr.carUserFuel.carUser.car.CarNumber,
                     ProductionYear = carUserFuelTypeBr.carUserFuel.carUser.car.ProductionYear,
                     Price = carUserFuelTypeBr.carUserFuel.carUser.car.Price,
                     SecondHand = carUserFuelTypeBr.carUserFuel.carUser.car.SecondHand,
                     AddingDate = carUserFuelTypeBr.carUserFuel.carUser.car.AddingDate,
                     Brand = carUserFuelTypeBr.brand,
                     User = carUserFuelTypeBr.carUserFuel.carUser.user,
                     FuelTypeNavigation = carUserFuelTypeBr.carUserFuel.fuelType,
                     CarType = carType
                 });
                 
        }
    }
}
