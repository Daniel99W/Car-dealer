using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Repositories
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(AnnouncesContext announcesContext)
            :base(announcesContext)
        {
           
        }



       
    }
}
