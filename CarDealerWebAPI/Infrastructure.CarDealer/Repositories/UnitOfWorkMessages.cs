using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Repositories
{
    public class UnitOfWorkMessages
    {
        private IRepositoryMessage _messageRepository;
        private IRepositoryMessageTo _messageToRepository;
        public UnitOfWorkMessages(
            IRepositoryMessage messageRepository,
            IRepositoryMessageTo messageToRepository)
        {
            _messageRepository = messageRepository;
            _messageToRepository = messageToRepository;
        }

        public async Task<Message> SendMessage(Message message,MessageTo messageTo)
        {
            _messageRepository.Create(message);
            _messageToRepository.Create(messageTo);

            await _messageRepository.SaveChangesAsync();
            await _messageToRepository.SaveChangesAsync();

            return message;
        }
    }
}
