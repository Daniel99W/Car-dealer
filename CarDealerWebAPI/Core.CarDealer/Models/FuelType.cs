using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class FuelType
    {
        public FuelType()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
