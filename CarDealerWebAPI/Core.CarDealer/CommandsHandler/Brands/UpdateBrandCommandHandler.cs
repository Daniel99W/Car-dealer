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
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Brand>
    {
        private IRepositoryBrand _repositoryBrand;
        public UpdateBrandCommandHandler(IRepositoryBrand repositoryBrand)
        {
            _repositoryBrand = repositoryBrand;
        }
        public async Task<Brand> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = await Task.FromResult(_repositoryBrand.Update(new Brand()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            }));
            await _repositoryBrand.SaveChangesAsync();
            return brand;
        }
    }
}
