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
    public class FuelTypeRepository : Repository<FuelType>,IRepositoryFuelType
    {
        public FuelTypeRepository(AnnouncesContext announcesContext)
            :base(announcesContext)
        {

        }

        public async Task<IEnumerable<FuelType>> GetFuelTypes()
        {
            return await _announcesContext.FuelTypes.ToListAsync();
        }
    }
}
