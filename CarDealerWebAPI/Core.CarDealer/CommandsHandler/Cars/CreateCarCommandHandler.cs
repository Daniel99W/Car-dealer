using Core.CarDealer.Commands;
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
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand,bool>
    {
        private IRepository<Car> _carRepository;

        public CreateCarCommandHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<bool> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            _carRepository.Create(new Car 
            { 
                CarNumber = request.CarNumber
            });

            await _carRepository.SaveChangesAsync();

            return true;
        }

    }
}
