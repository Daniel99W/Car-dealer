using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class UserCar
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CarId { get; set; }

        public virtual User? User { get; set; }
    }
}
