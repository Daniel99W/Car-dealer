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

        public async override Task<Message?> Read(Guid id)
        {
            return await _announcesContext.
                Messages
                .Join(_announcesContext.Users,
                message => message.UserId,
                user => user.Id,
                (message, user) => new Message()
                {
                    Id = message.Id,
                    UserId = user.Id,
                    User = user,
                    Content = message.Content,
                    Subject = message.Subject,
                    Created = message.Created
                })
                .FirstOrDefaultAsync();
                
        }

        public async Task<Message?> GetMessageBySubject(string subject)
        {
            return await _announcesContext.Messages
                .Where(message => message.Content.Contains(subject))
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Message>> GetMessages(Guid receiverId)
        {
            return await _announcesContext.Messages
                .Join(_announcesContext.MessageTos,
                message => message.Id,
                messageTo => messageTo.MessageId,
                (message, messageTo) => new { message, messageTo })
                .Where(message =>message.messageTo.UserId == receiverId)
                .Select(message => new Message()
                {
                    Id = message.message.Id,
                    UserId = message.message.UserId,
                    Content = message.message.Content,
                    Subject = message.message.Subject,
                    User = _announcesContext.Users.Where(u => u.Id == receiverId).FirstOrDefault()
                })
                .ToListAsync();
        }

    }
}
