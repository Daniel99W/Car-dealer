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

        public async Task<IEnumerable<Message>>? GetMessages(int senderId,int receiverId)
        {
            return await _announcesContext.Messages
                .Join(_announcesContext.MessageTos,
                message => message.Id,
                messageTo => messageTo.MessageId,
                (message, messageTo) => new { message, messageTo })
                .Where(message => message.message.UserId == senderId && message.messageTo.UserId == receiverId)
                .Select(message => new Message()
                {
                    Id = message.message.Id,
                    UserId = message.message.UserId,
                    Content = message.message.Content
                })
                .ToListAsync();
        }

    }
}
