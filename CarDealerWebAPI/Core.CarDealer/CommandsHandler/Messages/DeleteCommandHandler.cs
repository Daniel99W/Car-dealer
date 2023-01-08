using Core.CarDealer.Commands.Mesages;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.Messages
{
    public class DeleteCommandHandler : IRequestHandler<DeleteMessageCommand, Unit>
    {
        IRepositoryMessage _repositoryMessage;
        public DeleteCommandHandler(IRepositoryMessage repositoryMessage)
        {
            _repositoryMessage = repositoryMessage;
        }
        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            _repositoryMessage.Delete(new Message()
            {
                Id = request.Id,
            });
            await _repositoryMessage.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
