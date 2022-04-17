using Core.CarDealer.DTO;
using Core.CarDealer.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Commands.Images
{
    public class CreateImageCommand : IRequest<Image>
    {
        public Guid CarId { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
