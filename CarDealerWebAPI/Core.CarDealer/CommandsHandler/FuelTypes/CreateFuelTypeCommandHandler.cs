using Core.CarDealer.Commands.FuelTypes;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.FuelTypes
{
    public class CreateFuelTypeCommandHandler : IRequestHandler<CreateFuelTypeCommand,FuelType>
    {
        private IRepositoryFuelType _repositoryFuelType;
        public CreateFuelTypeCommandHandler(IRepositoryFuelType repositoryFuelType)
        {
            _repositoryFuelType = repositoryFuelType;
        }

        public async Task<FuelType> Handle(CreateFuelTypeCommand request, CancellationToken cancellationToken)
        {
            FuelType fuelType =  _repositoryFuelType.Create(new FuelType()
            {
                Name = request.Name,
            });

            await _repositoryFuelType.SaveChangesAsync();

            return await Task.FromResult(fuelType);
        }
    }
}
