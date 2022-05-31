using Core.CarDealer.Commands.Brands;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.Brands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private IRepositoryBrand _repositoryBrand;
        public DeleteBrandCommandHandler(IRepositoryBrand repositoryBrand)
        {
            _repositoryBrand = repositoryBrand;
        }
        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            _repositoryBrand.Delete(new Brand()
            {
                Id = request.Id,
            });
            await _repositoryBrand.SaveChangesAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
