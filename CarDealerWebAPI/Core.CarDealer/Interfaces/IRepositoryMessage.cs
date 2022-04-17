using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
    public interface IRepositoryMessage : IRepository<Message>
    {

        public Task<IEnumerable<Message>> GetMessages(Guid senderId,Guid receiverId);

        public Task<Message>? GetMessageBySubject(string subject);
    }
}
