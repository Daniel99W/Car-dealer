using System;
using System.Collections.Generic;

namespace Core.CarDealer.Models
{
    public partial class User
    {
        public User()
        {
            Cars = new HashSet<Car>();
            MessageTos = new HashSet<MessageTo>();
            Messages = new HashSet<Message>();
            UserCars = new HashSet<UserCar>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<MessageTo> MessageTos { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserCar> UserCars { get; set; }
    }
}
