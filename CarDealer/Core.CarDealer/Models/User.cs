using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class User
    {
        public User()
        {
            Cars = new HashSet<Car>();
            MessageTos = new HashSet<MessageTo>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? RolId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<MessageTo> MessageTos { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
