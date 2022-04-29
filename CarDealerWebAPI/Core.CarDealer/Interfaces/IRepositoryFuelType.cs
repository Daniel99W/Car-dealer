using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
    public interface IRepositoryFuelType : IRepository<FuelType>
    {
        public Task<IEnumerable<FuelType>> GetFuelTypes();
    }
}
