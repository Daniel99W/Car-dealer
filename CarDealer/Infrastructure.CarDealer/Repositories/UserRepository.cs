using CarDealer.Models;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models.ResultModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<UserResultModel>> GetAllUsers()
        {
            return await announces.Users
                .Select(user => new UserResultModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    SecondName = user.SecondName,
                    Email = user.Email,
                    RolId = user.RolId
                })
                .ToListAsync();
        }
    }
}
