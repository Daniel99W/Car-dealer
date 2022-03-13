using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class CarEquipment
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? EquipmentId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
