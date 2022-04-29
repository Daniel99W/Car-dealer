using Core.CarDealer.Interfaces;
using Core.CarDealer.Models;
using Core.CarDealer.Queries.Images;
using MediatR;

namespace Core.CarDealer.QueriesHandler.Images
{
    public class GetImageByNameQueryHandler : IRequestHandler<GetImageByNameQuery, Image>
    {
        private IRepositoryImage _repositoryImage;
        public GetImageByNameQueryHandler()
        {

        }

        public async Task<Image>? Handle(GetImageByNameQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryImage.GetImageByName(request.ImageName);
        }
    }
}
