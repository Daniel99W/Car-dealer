using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Images;
using MediatR;

namespace Core.CarDealer.QueriesHandler.Images
{
    public class GetImagesByCarIdQueryHandler :
        IRequestHandler<GetImagesByCarIdQuery, IEnumerable<Image>>
    {
        private IRepositoryImage _repositoryImage;
        private ICloudStorageService _cloudStorageService;

        public GetImagesByCarIdQueryHandler(
            IRepositoryImage repositoryImage,
            ICloudStorageService cloudStorageService
            )
        {
            _repositoryImage = repositoryImage;
            _cloudStorageService = cloudStorageService;
        }


        public async Task<IEnumerable<Image>> Handle(GetImagesByCarIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryImage.GetImagesByCarId(request.CarId);
        }
    }
}
