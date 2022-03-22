using Core.CarDealer.Commands.Messages;
using Core.CarDealer.Models;
using Core.CarDealer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.Messages
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand,Message>
    {
        private IRepositoryMessage _repositoryMesssage;
        public CreateMessageCommandHandler(IRepositoryMessage repositoryMessage)
        {
            _repositoryMesssage = repositoryMessage;
        }

        public async Task<Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            Message message = _repositoryMesssage.Create(new Message
            {
                Subject = request.Subject,
                Content = request.Content,
                UserId = request.UserId 
            });
            return await Task.FromResult(message);
        }
    }
}
