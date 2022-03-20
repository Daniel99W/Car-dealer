using Core.CarDealer.DTO;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(AnnouncesContext announcesContext) 
            :base(announcesContext)
        {
           
        }

        public Task<User>? Read(string name)
        {
            throw new NotImplementedException();
        }
    }
}
