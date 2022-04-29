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
    public class BrandRepository : Repository<Brand>,IRepositoryBrand
    {
        public BrandRepository(AnnouncesContext announcesContext)
            :base(announcesContext)
        {

        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _announcesContext.Brands.ToListAsync();
        }
    }
}
