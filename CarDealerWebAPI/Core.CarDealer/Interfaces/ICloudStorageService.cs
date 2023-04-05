using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CarDealer.Interfaces
{
    public interface ICloudStorageService
    {
        public Task<string> GetSignedUrlAsync(string filennameToRead);
        public Task<string> UploadFileAsync(IFormFile fileToUpload, string fileName);
        public Task DeleteFileAsync(string fileNameToDelete);
    }
}
