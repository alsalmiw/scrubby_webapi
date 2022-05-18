using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using scrubby_webapi.Services.Context;

namespace scrubby_webapi.Services
{
    public class PhotosService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public PhotosService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<Uri> UploadImage(string blobContainerName, Stream content, string contentType, string fileName)
        {
            var containerClient = GetContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });


                return blobClient.Uri;


         }

         private BlobContainerClient GetContainerClient(string blobContainerClient)
         {
             var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerClient);
             containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
         }
    }
}