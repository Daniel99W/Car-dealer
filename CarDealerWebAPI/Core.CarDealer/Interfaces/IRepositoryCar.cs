using Core.CarDealer.DTO;
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
        public Task<PaginatedDTO<Car>> GetCars(
            int page,
            int carsPerPage,
            Guid? CarTypeId,
            Guid? BrandId,
            string? title,
            int? minProductionYear,
            int? maxProductionYear,
            int? minPrice,
            int? maxPrice,
            bool? orderBy,
            Guid? userId
            );

        public Task<int> GetCarsNumber(Guid? userId);

        public Task<Car?> GetCarByUserId(Guid id);

        public Task<IEnumerable<Car>> GetCarsByUserId(Guid userId);

        public Task<int> GetCarsTotalPrice();

    }
}
