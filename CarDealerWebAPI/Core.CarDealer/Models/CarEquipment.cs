using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class CarEquipment
    {
        public Guid Id { get; set; }
        public Guid? CarId { get; set; }
        public Guid? EquipmentId { get; set; }

        public virtual Car? Car { get; set; }
        public virtual Equipment? Equipment { get; set; }
    }
}
