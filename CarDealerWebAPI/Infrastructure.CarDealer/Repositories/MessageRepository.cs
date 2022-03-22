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
    public class MessageRepository : Repository<Message>,IRepositoryMessage
    {
        public MessageRepository(AnnouncesContext announcesContext)
            :base(announcesContext)
        {
           
        }

        public async Task<Message>? GetMessageBySubject(string subject)
        {
            return await _announcesContext.Messages
                .Where(message => message.Content.Contains(subject))
                .SingleOrDefaultAsync();
        }

        public Task<IEnumerable<Message>> GetMessages(int? userId)
        {
            throw new NotImplementedException();
        }

        public Task SendMessage(int senderId, int receiverId)
        {
            throw new NotImplementedException();
        }
    }
}
