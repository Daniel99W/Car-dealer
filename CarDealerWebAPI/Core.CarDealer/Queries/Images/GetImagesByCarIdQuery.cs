using Core.CarDealer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Queries.Images
{
    public class GetImagesByCarIdQuery : IRequest<IEnumerable<Image>>
    {
        public Guid CarId { get; set; }
    }
}
