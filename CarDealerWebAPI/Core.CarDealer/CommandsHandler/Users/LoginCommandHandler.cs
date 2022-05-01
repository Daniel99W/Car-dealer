using Core.CarDealer.Commands.Users;
using Core.CarDealer.DTO;
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
    public class LoginCommandHandler : IRequestHandler<LoginUserCommand, JwtSecurityToken?>
    {
        private IServiceAuth _authService;
        private IRepositoryUser _repositoryUser;
        public LoginCommandHandler(IServiceAuth serviceAuth,IRepositoryUser repositoryUser)
        {
            _authService = serviceAuth;
            _repositoryUser = repositoryUser;
        }

        public async Task<JwtSecurityToken?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            User? user = await _repositoryUser.GetUserByEmail(request.Email);

            if (user == null || !_authService.CheckPassword(new LoginDTO()
            {
                Email = request.Email,
                Password = request.Password,
            }, user))
            {
                return null;
            }

            return await _authService.GetJwt(user);
        }
    }
}
