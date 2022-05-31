using Core.CarDealer.Commands.Cars;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;

namespace Core.CarDealer.CommandsHandler.Cars
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand,Guid>
    {
        private IRepositoryCar _repositoryCar;
        public DeleteCarCommandHandler(IRepositoryCar repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }

        public async Task<Guid> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            _repositoryCar.Delete(new Car()
            {
                Id = request.Id
            });
            await _repositoryCar.SaveChangesAsync();

            return await Task.FromResult(request.Id);
        }
    }
}
