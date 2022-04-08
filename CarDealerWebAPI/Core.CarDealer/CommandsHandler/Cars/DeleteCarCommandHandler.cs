using Core.CarDealer.Commands.Cars;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.Cars
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand,int>
    {
        private IRepositoryCar _repositoryCar;
        public DeleteCarCommandHandler(IRepositoryCar repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }

        public async Task<int> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            _repositoryCar.Delete(new Car()
            {
                Id = request.Id
            });

            return await Task.FromResult(request.Id);
        }
    }
}
