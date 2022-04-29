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
    public  class CreateCarTypeCommandHandler : IRequestHandler<CreateCarTypeCommand,CarType>
    {
        IRepositoryCarType _repositoryCarType;
        public CreateCarTypeCommandHandler(IRepositoryCarType repositoryCarType)
        {
            _repositoryCarType = repositoryCarType;
        }

        public async Task<CarType> Handle(CreateCarTypeCommand request, CancellationToken cancellationToken)
        {
            CarType carType =  await Task.FromResult(_repositoryCarType.Create(new CarType
            {
                Name = request.Name,
            }));

            await _repositoryCarType.SaveChangesAsync();

            return carType;
        }
    }
}
