using Core.CarDealer.Commands.CarTypes;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.CarTypes
{
    public class UpdateCarTypeCommandHandler : IRequestHandler<UpdateCarTypeCommand, CarType>
    {
        private IRepositoryCarType _repositoryCarType;
        public UpdateCarTypeCommandHandler(IRepositoryCarType repositoryCarType)
        {
            _repositoryCarType = repositoryCarType;
        }
        public async Task<CarType> Handle(UpdateCarTypeCommand request, CancellationToken cancellationToken)
        {
            CarType carType = _repositoryCarType.Update(new CarType()
            {
                Id = request.Id,
                Name = request.Name,
            });
            await _repositoryCarType.SaveChangesAsync();
            return carType;
        }
    }
}
