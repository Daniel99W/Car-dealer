using AutoMapper;
using Core.CarDealer.Commands.Users;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;

namespace Core.CarDealer.CommandsHandler.Users
{
    public  class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,User>
    {
        private IRepositoryUser _repositoryUser;
        private IMapper _mapper;
        public CreateUserCommandHandler(
            IRepositoryUser repositoryUser,
            IMapper mapper)
        {
            _repositoryUser = repositoryUser;
            _mapper = mapper;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _repositoryUser.Create(_mapper.Map<User>(request));

            await _repositoryUser.SaveChangesAsync();

            return await Task.FromResult(user);
        }
    }
}
