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

        private int id;
        private string name;
        private string secondName;
        private string password;
        private string email;
        private int? rolId;

        private  Rol rol;
        private  ICollection<Car> cars;
        private  ICollection<MessageTo> messageTos;
        private  ICollection<Message> messages;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int? RolId { get => rolId; set => rolId = value; }
        public Rol Rol { get => rol; set => rol = value; }
        public ICollection<Car> Cars { get => cars; set => cars = value; }
        public ICollection<MessageTo> MessageTos { get => messageTos; set => messageTos = value; }
        public ICollection<Message> Messages { get => messages; set => messages = value; }
    }
}
