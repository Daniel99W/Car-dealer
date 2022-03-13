using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            CarEquipments = new HashSet<CarEquipment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CarEquipment> CarEquipments { get; set; }
    }
}
