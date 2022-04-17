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
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, Guid>
    {
        private IRepositoryImage _repositoryImage;
        private IServiceBlob _blobService;
        public DeleteImageCommandHandler(
            IRepositoryImage repositoryImage,
            IServiceBlob serviceBlob
            )
        {
            _repositoryImage = repositoryImage;
            _blobService = serviceBlob;
        }

        public Task<Guid> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            _repositoryImage.Delete(new Image
            {
                CarId = request.CarId,
                ImageName = request.ImageName
            });

            _blobService.Remove(request.ImageName);
            return Task.FromResult(request.CarId);
        }
    }
}
