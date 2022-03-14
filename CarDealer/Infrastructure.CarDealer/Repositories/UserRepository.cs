using CarDealer.Models;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Repositories
{
    public class UserRepository : IRepository<User,User>
    {
        private AnnouncesContext announces;

        public UserRepository(AnnouncesContext announces)
        {
            this.announces = announces;
        }

        public async void Create(User obj)
        {
            announces.Add(obj);
            await announces.SaveChangesAsync();
        }

        public void Delete(User obj)
        {
            announces.Users.Remove(obj);
        }

        public async Task<User>? Read(int id)
        {
            return await announces.Users.FindAsync(id);
        }

        public void Update(User obj)
        {
           announces.Users.Update(obj);
        }
    }
}
