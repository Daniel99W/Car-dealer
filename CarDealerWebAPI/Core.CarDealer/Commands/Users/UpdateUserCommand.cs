using Core.CarDealer.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Users
{
    public class UpdateUserCommand : IRequest<UserDTO>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Role { get; set; }
    }
}
