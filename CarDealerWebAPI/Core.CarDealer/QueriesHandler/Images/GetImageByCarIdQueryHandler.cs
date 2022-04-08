using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Images;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.QueriesHandler.Images
{
    public class GetImagesByCarIdQueryHandler :
        IRequestHandler<GetImagesByCarIdQuery, IEnumerable<Image>>
    {
        IRepositoryImage _repositoryImage;
        IServiceBlob _blobService;

        public GetImagesByCarIdQueryHandler(
            IRepositoryImage repositoryImage,
            IServiceBlob blobService
            )
        {
            _repositoryImage = repositoryImage;
            _blobService = blobService;
        }


        public async Task<IEnumerable<Image>> Handle(GetImagesByCarIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryImage.GetImagesByCarId(request.CarId);
        }
    }
}
