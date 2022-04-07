using Core.CarDealer.Commands.Images;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.CommandsHandler.Images
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, Image>
    {
        private IServiceBlob _serviceBlob;
        private IRepositoryImage _repositoryImage;
        public CreateImageCommandHandler(
            IServiceBlob serviceBlob,
            IRepositoryImage repositoryImage)
        {
            _serviceBlob = serviceBlob;
            _repositoryImage = repositoryImage;
        }
        public async Task<Image> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
           //await _serviceBlob.Upload(request.FormFile);
           Image image =  _repositoryImage.Create(new Image()
            {
                ImageUrl = request.FormFile.FileName,
                CarId = request.CarId
            });

            await _repositoryImage.SaveChangesAsync();

            return await Task.FromResult(image);
        }
    }
}
