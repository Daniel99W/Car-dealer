using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int? CarId { get; set; }

        public virtual Car? Car { get; set; }
    }
}
