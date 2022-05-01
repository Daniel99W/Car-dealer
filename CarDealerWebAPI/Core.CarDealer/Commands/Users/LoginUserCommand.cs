using MediatR;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Users
{
    public class LoginUserCommand : IRequest<JwtSecurityToken?>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
