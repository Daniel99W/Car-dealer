using MediatR;

namespace Core.CarDealer.Commands.Cars
{
    public class DeleteCarCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
