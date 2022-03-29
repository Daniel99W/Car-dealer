using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.Messages
{
    public class GetMessageByUserIdHandler : IRequestHandler<GetMessageByUserIdQuery, Message>
    {
        private IRepositoryMessage _repositoryMessage;
        public GetMessageByUserIdHandler(IRepositoryMessage repositoryMessage)
        {
            _repositoryMessage = repositoryMessage;
        }
        public async Task<Message>? Handle(GetMessageByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryMessage.GetMessageByUserId(request.userId);
        }
    }
}
