using AutoMapper;
using Core.CarDealer.Commands.Users;
using Core.CarDealer.DTO;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        private IRepositoryUser _repositoryUser;
        private IMapper _mapper;
        public UpdateUserCommandHandler(
            IRepositoryUser repositoryUser,
            IMapper mapper)
            
        {
            _repositoryUser = repositoryUser;
            _mapper = mapper;

        }
        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User ? user = await _repositoryUser.GetUserByEmail(request.Email);
            UserDTO userDTO = new UserDTO();
            if (user != null)
            {
                user.Email = request.Email;
                user.SecondName = request.SecondName;
                user.Name = request.Name;
                _repositoryUser.Update(user);
                userDTO.Email = user.Email;
                userDTO.SecondName = user.SecondName;
                userDTO.Name = user.Name;
            }
            await _repositoryUser.SaveChangesAsync();
            return userDTO;
        }
    }
}
