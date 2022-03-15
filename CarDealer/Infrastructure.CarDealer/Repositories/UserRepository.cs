using CarDealer.Models;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private AnnouncesContext announces;

        public UserRepository(AnnouncesContext announces)
        {
            this.announces = announces;
        }

        public void Create(User obj)
        {
            announces.Users.Add(obj);
            announces.SaveChanges();
        }

        public void Delete(User user)
        {
            announces.Users.Remove(user);
            announces.SaveChanges();
        }

        public async Task<User>? Read(int id)
        {
            return await announces.Users.FindAsync(id);
        }

        public void Update(User obj)
        {
           announces.Users.Update(obj);
           announces.SaveChanges();
        }
    }
}
