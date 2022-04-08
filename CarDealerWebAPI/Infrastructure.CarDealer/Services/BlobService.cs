using Azure.Storage.Blobs;
using Core.CarDealer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Services
{
    public class BlobService : IServiceBlob
    {
        private BlobServiceClient _blobServiceClient;
        private IConfiguration _configuration;
        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            BlobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("AzureBlobCarDealer"));
        }

        public BlobServiceClient BlobServiceClient 
        { get => _blobServiceClient; set => _blobServiceClient = value; }

        public async Task<Stream> GetImage(string imageName)
        {
            BlobContainerClient blobContainer = _blobServiceClient.GetBlobContainerClient(
                _configuration["AzureImagesContainer"]);
            BlobClient blobClient = blobContainer.GetBlobClient(imageName);

            Stream? image = null;
            await blobClient.DownloadToAsync(image);
            
            return image;
        }

        public async Task Upload(IFormFile formFile)
        {
            BlobContainerClient blobContainer = _blobServiceClient.GetBlobContainerClient(
                _configuration["AzureImagesContainer"]);
            BlobClient blobClient = blobContainer.GetBlobClient(formFile.FileName);
            
            await blobClient.UploadAsync(formFile.OpenReadStream());
        }

      
    }
}
