using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
