using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class UserCar
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }

        public virtual User? User { get; set; }
    }
}
