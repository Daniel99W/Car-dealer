using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Commands.Mesages;

namespace Core.CarDealer.CommandsHandler.Messages
{
    public class CreateUnitOfWorkMessagesCommandHandler : IRequestHandler<CreateUnitOfWorkMessagesCommand,Unit>
    {
        IUnitOfWork _unitOfWork;
        public CreateUnitOfWorkMessagesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateUnitOfWorkMessagesCommand request, CancellationToken cancellationToken)
        {
            Message message = _unitOfWork._repositoryMessage.Create(new Message()
            {
                Content = request.Content,
                Subject = request.Subject,
                UserId = request.UserId,
                Created = DateTime.Now
            });
           await _unitOfWork._repositoryMessage.SaveChangesAsync();
           _unitOfWork._repositoryMessageTo.Create(new MessageTo()
           {
                UserId = request.ReceiverId,
                MessageId = message.Id
           });
           await _unitOfWork._repositoryMessageTo.SaveChangesAsync();
           return await Task.FromResult(Unit.Value);
        }
    }
}
