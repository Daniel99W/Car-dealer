using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class Car
    {
        public Car()
        {
            CarEquipments = new HashSet<CarEquipment>();
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string CarNumber { get; set; } = null!;
        public int? ProductionYear { get; set; }
        public int Price { get; set; }
        public bool? SecondHand { get; set; }
        public DateTime AddingDate { get; set; }
        public int? UserId { get; set; }
        public int? FuelType { get; set; }
        public string Description { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int CilindricCapacity { get; set; }
        public int? BrandId { get; set; }
        public int? CarTypeId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual CarType? CarType { get; set; }
        public virtual FuelType? FuelTypeNavigation { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<CarEquipment> CarEquipments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
