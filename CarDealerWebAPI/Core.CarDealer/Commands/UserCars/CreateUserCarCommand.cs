using MediatR;
using Core.CarDealer.Models;

namespace Core.CarDealer.Commands.UserCars
{
    public class CreateUserCarCommand : IRequest<UserCar>
    {
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
    }
}
