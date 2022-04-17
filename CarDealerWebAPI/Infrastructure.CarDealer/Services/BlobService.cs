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
        private BlobContainerClient _blobContainerClient;
        private IConfiguration _configuration;
        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            BlobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("AzureBlobCarDealer"));
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(
                _configuration.GetConnectionString("AzureImagesContainer"));
        }

        public BlobServiceClient BlobServiceClient 
        { get => _blobServiceClient; set => _blobServiceClient = value; }


        public async Task Remove(string imageName)
        {
           await _blobContainerClient.DeleteBlobAsync(imageName);
        }

        public async Task Upload(IFormFile formFile)
        {
            
            BlobClient blobClient = _blobContainerClient.GetBlobClient(formFile.FileName);
            
            await blobClient.UploadAsync(formFile.OpenReadStream());
        }

      
    }
}
