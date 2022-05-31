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
    public class DeleteCarTypeCommandHandler : IRequestHandler<DeleteCarTypeCommand, Unit>
    {
        private IRepositoryCarType _repositoryCarType;

        public DeleteCarTypeCommandHandler(IRepositoryCarType repositoryCarType)
        {
            _repositoryCarType = repositoryCarType;
        }
        public Task<Unit> Handle(DeleteCarTypeCommand request, CancellationToken cancellationToken)
        {
            _repositoryCarType.Delete(new CarType()
            {
                Id = request.Id,
            });
            _repositoryCarType.SaveChangesAsync();
            return Task.FromResult(Unit.Value);
        }
    }
}
