using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class Image
    {
        public Guid Id { get; set; }
        public string ImageName { get; set; } = null!;
        public Guid? CarId { get; set; }

        public virtual Car? Car { get; set; }
    }
}
