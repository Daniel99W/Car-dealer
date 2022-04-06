using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
    public interface IRepositoryImage : IRepository<Image>
    {
        public Task<IEnumerable<Image>> GetImagesByCarId(int carId);
    }
}
