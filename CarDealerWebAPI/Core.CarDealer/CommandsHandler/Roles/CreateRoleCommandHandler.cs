using Core.CarDealer.Commands.Roles;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.Roles
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Role>
    {
        private IRepositoryRole _roleRepository;
        public CreateRoleCommandHandler(IRepositoryRole roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Role role = _roleRepository.Create(new Role()
            {
                Name = request.RoleName
            });
            await _roleRepository.SaveChangesAsync();
            return role;
        }
    }
}
