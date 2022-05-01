using Core.CarDealer.Commands.Users;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.Users
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, Unit>
    {
        private IServiceAuth _serviceAuth;
        private IRepositoryRole _repositoryRole;
        public SignUpUserCommandHandler(IServiceAuth authService,IRepositoryRole repositoryRole)
        {
            _serviceAuth = authService;
            _repositoryRole = repositoryRole;
        }

        public async Task<Unit> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            Guid ? roleId = await _repositoryRole.GetRoleIdByName("user");

            await _serviceAuth.SignUpUser(new User()
            {
                Email = request.Email,
                Password = request.Password,
                Name = request.Name,
                SecondName = request.SecondName,
            }
            ,(Guid)roleId);
            return await Task.FromResult(Unit.Value);
        }
    }
}
