using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.DTO
{
    public class ImageDTO
    {
        public string ImageUrl { get; set; }
        public int CarId { get; set; }
    }
}
