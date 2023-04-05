using Core.CarDealer.Commands.Images;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;

namespace Core.CarDealer.CommandsHandler.Images
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, Guid>
    {
        private IRepositoryImage _repositoryImage;
        private ICloudStorageService _cloudStorageService;
        public DeleteImageCommandHandler(
            IRepositoryImage repositoryImage,
            ICloudStorageService cloudStorageService
            )
        {
            _repositoryImage = repositoryImage;
            _cloudStorageService = cloudStorageService;
        }

        public Task<Guid> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            _repositoryImage.Delete(new Image
            {
                CarId = request.CarId,
                ImageName = request.ImageName
            });

            _cloudStorageService.DeleteFileAsync(request.ImageName);
            return Task.FromResult(request.CarId);
        }
    }
}
