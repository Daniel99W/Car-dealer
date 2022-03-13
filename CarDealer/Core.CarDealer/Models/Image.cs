using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class Image
    {
        public Image()
        {
            CarImages = new HashSet<CarImage>();
        }

        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<CarImage> CarImages { get; set; }
    }
}
