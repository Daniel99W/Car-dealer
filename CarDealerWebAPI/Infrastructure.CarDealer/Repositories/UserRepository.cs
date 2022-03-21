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
    public class UserRepository : Repository<User>,IRepositoryUser
    {
        public UserRepository(AnnouncesContext announcesContext) 
            :base(announcesContext)
        {
           
        }
    }
}
