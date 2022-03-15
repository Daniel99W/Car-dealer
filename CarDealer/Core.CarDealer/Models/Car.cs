using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class Car
    {
        public Car()
        {
            CarEquipments = new HashSet<CarEquipment>();
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string CarNumber { get; set; }
        public int? ProductionYear { get; set; }
        public int Price { get; set; }
        public bool? SecondHand { get; set; }
        public DateTime AddingDate { get; set; }
        public int? UserId { get; set; }
        public int? FuelType { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public int CilindricCapacity { get; set; }
        public int? BrandId { get; set; }
        public int? CarTypeId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual CarType CarType { get; set; }
        public virtual FuelType FuelTypeNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CarEquipment> CarEquipments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
