using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            CarEquipments = new HashSet<CarEquipment>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<CarEquipment> CarEquipments { get; set; }
    }
}
