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
    public class ImageRepository : Repository<Image>,IRepositoryImage
    {
        public ImageRepository(AnnouncesContext announcesContext)
            :base(announcesContext)
        {

        }

        public async Task<IEnumerable<Image>> GetImagesByCarId(int carId)
        {
            return await _announcesContext.Images.Where(image => image.CarId == carId)
                .ToListAsync();
        }
    }
}
