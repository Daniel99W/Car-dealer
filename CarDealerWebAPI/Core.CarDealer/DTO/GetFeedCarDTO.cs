using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class GetFeedCarDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CarNumber { get; set; }
        public int? ProductionYear { get; set; }
        public int Price { get; set; }
        public bool? SecondHand { get; set; }
        public DateTime AddingDate { get; set; }
        public Guid? UserId { get; set; }
        public Guid? FuelType { get; set; }
        public string Description { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int CilindricCapacity { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? CarTypeId { get; set; }

        public Image Image { get; set; }
    }
}
