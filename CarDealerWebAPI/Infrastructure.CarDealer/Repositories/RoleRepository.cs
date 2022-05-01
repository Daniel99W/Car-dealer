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
    public class RoleRepository : Repository<Role>,IRepositoryRole
    {
        public RoleRepository(AnnouncesContext announcesContext)
            :base(announcesContext)
        {

        }

        public async Task<Guid?> GetRoleIdByName(string roleName)
        {
            Role ? role = await _announcesContext.Roles.Where(r => r.Name == roleName)
                .FirstOrDefaultAsync();
            if (role == null)
                return null;
            return role.Id;
            
        }
    }
}
