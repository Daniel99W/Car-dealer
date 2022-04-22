using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class FavoriteDTO
    {
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
    }
}
