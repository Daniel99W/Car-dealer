using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
    public interface IServiceBlob
    {
        public Task Upload(IFormFile formFile);

        public Task Remove(string imageName);


    }
}
