using CarDealer.Models;
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
                 (car, user) => new Car
                 {
                     Id = car.Id,
                     UserId = user.Id,
                     User = new User()
                     {
                         Id = user.Id
                     }
                 });
                 
                 
        }
    }
}
