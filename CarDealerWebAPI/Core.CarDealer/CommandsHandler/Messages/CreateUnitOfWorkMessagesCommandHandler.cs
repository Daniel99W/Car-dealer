using Core.CarDealer.Commands.Messages;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CarDealer.Interfaces;

namespace Core.CarDealer.CommandsHandler.Messages
{
    public class CreateUnitOfWorkMessagesCommandHandler : IRequestHandler<CreateUnitOfWorkMessagesCommand,Message>
    {
        IUnitOfWork _unitOfWork;
        public CreateUnitOfWorkMessagesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Message> Handle(CreateUnitOfWorkMessagesCommand request, CancellationToken cancellationToken)
        {
           Message message =  _unitOfWork._repositoryMessage.Create(new Message()
           {
                Subject = request.Subject,
                Content = request.Content,
                UserId = request.UserId
           });
           await _unitOfWork._repositoryMessage.SaveChangesAsync();
           _unitOfWork._repositoryMessageTo.Create(new MessageTo()
           {
                UserId = request.ReceiverId,
                MessageId = message.Id
           });
           await _unitOfWork._repositoryMessageTo.SaveChangesAsync();
           return await Task.FromResult(message);
        }
    }
}
