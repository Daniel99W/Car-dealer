using Core.CarDealer.Commands.Images;
using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using MediatR;

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

            string fileName = request.FormFile.FileName[..request.FormFile.FileName.IndexOf('.')];
            string imageName = fileName + request.CarId.ToString() + ".jpg";

            Image image = _repositoryImage.Create(new Image()
            {
                ImageName = imageName,
                CarId = request.CarId
            });

            await _serviceBlob.Upload(Utilities.Utilities.CreateImageWithNewName(request.FormFile,imageName));

            await _repositoryImage.SaveChangesAsync();
            return await Task.FromResult(image);
        }
    }
}
