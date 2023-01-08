using AutoMapper;
using Core.CarDealer.DTO;
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
        IRequestHandler<GetMessagesByReceiverIdQuery,IEnumerable<GetMessageDTO>>
    {
        private IRepositoryMessage _repositoryMessage;
        private IMapper _mapper;
        public GetMessagesBySenderReceiverQueryHandler(
            IRepositoryMessage repositoryMessage,
            IMapper mapper
            )
        {
            _repositoryMessage = repositoryMessage;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMessageDTO>> Handle(
            GetMessagesByReceiverIdQuery request, 
            CancellationToken cancellationToken)
        {
            IEnumerable<Message> messages = await _repositoryMessage.GetMessages(request.ReceiverId);
            List<GetMessageDTO> getMessageDTOs = new  List<GetMessageDTO>();

            foreach (Message message in messages)
            {
                getMessageDTOs.Add(new GetMessageDTO()
                {
                    Id = message.Id,
                    Content = message.Content,
                    SenderId = (Guid)message.UserId,
                    Subject = message.Subject,
                    UserDTO = new GetUserDTO()
                    {
                        Id = message.User.Id,
                        Name = message.User.Name,
                        SecondName = message.User.SecondName,
                        Email = message.User.Email,
                    }
                });
            }

            return getMessageDTOs;
        }
    }
}
