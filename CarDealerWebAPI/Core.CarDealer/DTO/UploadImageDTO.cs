using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class UploadImageDTO
    {
        public Guid CarId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
