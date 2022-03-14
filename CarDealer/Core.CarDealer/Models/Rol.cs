using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealer.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<User>();
        }

        private int id;
        private string name;

        private  ICollection<User> users;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public ICollection<User> Users { get => users; set => users = value; }
    }
}
