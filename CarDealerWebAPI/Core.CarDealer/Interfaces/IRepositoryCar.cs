using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
    public interface IRepositoryCar : IRepository<Car>
    {
        public Task<IEnumerable<Car>> GetCars(
            string? CarType,
            string? Brand,
            int? productionYear,
            int? minPrice,
            int? maxPrice
            );

        public Task<int> GetCarsNumber();

        public Task<Car> GetCarByUserId(int id);

    }
}
