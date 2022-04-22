using Core.CarDealer.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.CarDealer.Commands.Images
{
    public class CreateImageCommand : IRequest<Image>
    {
        public Guid CarId { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
