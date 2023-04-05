using Core.CarDealer.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer.Services
{
    public class CloudStorageService : ICloudStorageService
    {
        private IConfiguration _configuration;
        private GoogleCredential _googleCredential;
        private StorageClient _storageClient;

        public CloudStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _googleCredential = GoogleCredential.FromFile(_configuration.GetConnectionString("GCPStorageFile"));
        }
        public async Task DeleteFileAsync(string fileNameToDelete)
        {
            using (var storageClient = StorageClient.Create(_googleCredential))
            {
                await storageClient.DeleteObjectAsync(_configuration["GCBucketName"], fileNameToDelete);
            }
        }

        public Task<string> GetSignedUrlAsync(string filennameToRead)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFileAsync(IFormFile fileToUpload, string fileName)
        {
            using (var memoryStream = new MemoryStream())
            {
                await fileToUpload.CopyToAsync(memoryStream);

                using (var storageClient = StorageClient.Create(_googleCredential))
                {
                    var uploadedFile = 
                        await storageClient.UploadObjectAsync(_configuration.GetConnectionString("GCBucketName"), fileName, fileToUpload.ContentType, memoryStream);

                    return uploadedFile.MediaLink;
                }

            }
        }
    }
}
