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
    public class DeleteImageCommand : IRequest<Guid>
    {
        public Guid CarId { get; set; }

        public string ImageName { get; set; }
    }
}
