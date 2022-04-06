using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Services
{
    public class BlobService
    {
        private BlobContainerClient _blobContainerClient;
        private BlobServiceClient _blobServiceClient;
        private IConfiguration _configuration;
        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            BlobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("AzureBlobCarDealer"));
            BlobContainerClient = BlobServiceClient.CreateBlobContainer("cardealerapipics");
        }

        public BlobContainerClient BlobContainerClient 
        { get => _blobContainerClient; set => _blobContainerClient = value; }
        public BlobServiceClient BlobServiceClient 
        { get => _blobServiceClient; set => _blobServiceClient = value; }
    }
}
