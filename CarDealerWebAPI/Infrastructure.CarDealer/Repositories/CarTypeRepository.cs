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
    public class CarTypeRepository : Repository<CarType>, IRepositoryCarType
    {
        public CarTypeRepository(AnnouncesContext announcesContext)
            :base(announcesContext)
        {

        }

        public async Task<IEnumerable<CarType>> GetCarTypes()
        {
            return await _announcesContext.CarTypes.ToListAsync();
        }
    }
}
