using CarDealer.Models;
using Core.CarDealer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Repositories
{
    public class MessagesRepository
    {
        private AnnouncesContext announcesContext;
        public MessagesRepository(AnnouncesContext announcesContext)
        {
            this.announcesContext = announcesContext;
        }

        public void Create(Message obj)
        {
            announcesContext.Messages.Add(obj);
        }

        public void Delete(Message obj)
        {
            announcesContext.Messages.Remove(obj);
        }

        public async Task<Message> Read(int id)
        {
            return await announcesContext.Messages.FindAsync(id);
        }

        public void Update(Message obj)
        {
            throw new NotImplementedException();
        }
    }
}
