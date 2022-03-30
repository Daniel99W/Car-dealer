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
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand,Car>
    {
        private IRepositoryCar _carRepository;

        public CreateCarCommandHandler(IRepositoryCar carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _carRepository.Create(new Car
            {
                Id = request.Id,
                CarNumber = request.CarNumber,
                ProductionYear = request.ProductionYear,
                Title = request.Title,
                Price = request.Price,
                SecondHand = request.SecondHand,
                AddingDate = request.AddingDate,
                UserId = request.UserId,
                FuelType = request.FuelType,
                Description = request.Description,
                Model = request.Model,
                CilindricCapacity = request.CilindricCapacity,
                BrandId = request.BrandId,
                CarTypeId = request.CarTypeId
            });

            await _carRepository.SaveChangesAsync();
            return await Task.FromResult(car);
        }

    }
}
