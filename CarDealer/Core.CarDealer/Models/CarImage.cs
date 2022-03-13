using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class CarImage
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? ImageId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Image Image { get; set; }
    }
}
