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
            int page,
            int carsPerPage,
            string? CarType,
            string? Brand,
            string? title,
            int? productionYear,
            int? minPrice,
            int? maxPrice,
            bool? orderBy
            );

        public Task<int> GetCarsNumber();

        public Task<Car> GetCarByUserId(int id);

        public Task<int> GetCarsTotalPrice();

    }
}
