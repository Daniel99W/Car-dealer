using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int? CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
