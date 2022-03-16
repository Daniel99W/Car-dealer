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

        protected int id;
        protected string name;
        protected string secondName;
        protected string email;
        protected int? rolId;
        private string password;


        public virtual Rol Rol { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<MessageTo> MessageTos { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Email { get => email; set => email = value; }
        public int? RolId { get => rolId; set => rolId = value; }
        public string Password { get => password; set => password = value; }
    }
}
