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
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, GetMessageDTO?>
    {
        private IRepositoryMessage _repositoryMessage;
        private IMapper _mapper;
        public GetMessageByIdQueryHandler(
            IRepositoryMessage repositoryMessage,
            IMapper mapper)
        {
            _repositoryMessage = repositoryMessage;
            _mapper = mapper;
        }
        public async Task<GetMessageDTO?> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            Message ? message = await _repositoryMessage.Read(request.Id);

            if (message != null)
            {
                return new GetMessageDTO()
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
                };
            }
            return null;
        }
    }
}
