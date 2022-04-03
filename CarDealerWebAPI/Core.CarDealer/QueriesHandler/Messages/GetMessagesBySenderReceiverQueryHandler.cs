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
    public class GetMessagesBySenderReceiverQueryHandler : 
        IRequestHandler<GetMessagesBySenderReceiverQuery,IEnumerable<Message>>
    {
        private IRepositoryMessage _repositoryMessage;
        public GetMessagesBySenderReceiverQueryHandler(IRepositoryMessage repositoryMessage)
        {
            _repositoryMessage = repositoryMessage;
        }

        public async Task<IEnumerable<Message>> Handle(GetMessagesBySenderReceiverQuery request, CancellationToken cancellationToken)
        {
            return await
                _repositoryMessage.GetMessages(request.SenderId, request.ReceiverId);
        }
    }
}
