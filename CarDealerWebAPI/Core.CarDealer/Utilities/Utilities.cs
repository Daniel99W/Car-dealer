using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Utilities
{
    public static class Utilities
    {
        public static IFormFile CreateImageWithNewName(IFormFile formFile,Guid carId)
        {
            string fileName = formFile.FileName[..formFile.FileName.IndexOf('.')];
            Console.WriteLine(fileName);
            string imageName = fileName + carId.ToString();
            FormFile newFormFile = new FormFile(formFile.OpenReadStream(), 0, formFile.Length,
                imageName, imageName);

            return newFormFile;
        }
    }
}
