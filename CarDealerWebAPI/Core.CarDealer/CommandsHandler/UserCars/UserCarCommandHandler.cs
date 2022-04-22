using AutoMapper;
using Core.CarDealer.Commands.UserCars;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;

namespace Core.CarDealer.CommandsHandler.UserCars
{
    public class UserCarCommandHandler : IRequestHandler<CreateUserCarCommand,UserCar>
    {
        private IRepositoryUserCar _repositoryUserCar;
        private IMapper _mapper;
        public UserCarCommandHandler(
            IRepositoryUserCar repositoryUserCar,
            IMapper mapper)
            
        {
            _repositoryUserCar = repositoryUserCar;
            _mapper = mapper;
        }

        public async Task<UserCar> Handle(CreateUserCarCommand request, CancellationToken cancellationToken)
        {
            UserCar userCar = _repositoryUserCar.Create(_mapper.Map<UserCar>(request));
            await _repositoryUserCar.SaveChangesAsync();
            return userCar;

        }
    }
}
