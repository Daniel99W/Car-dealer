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
        public Task<Message>? GetMessageByUserId(int userId);

        public Task<IEnumerable<Message>> GetMessages(int? userId);

        public Task<Message>? GetMessageBySubject(string subject);
    }
}
