using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;
using Azure.Storage.Blobs;
using System.Configuration;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Jupiter.Services
{
    public class BlobShit

    {
        private static IConfiguration _configuration;
        
        public BlobShit(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            string secretString = string.Empty;
            secretString = _configuration["JupiterJazzKeyValutSecretKeyJupiterJazzStorageConnectionString"];
        }
       /* ConfigurationManager.AppSettings.GetValues("ldb");
        var someSetting = Environment.ExpandEnvironmentVariables(
                     ConfigurationManager.ConnectionStrings.AddBlobServiceClient
        BlobServiceClient blobServiceClient = new BlobServiceClient(Environment.ExpandEnvironmentVariables.);
        // Create a BlobServiceClient object which will be used to create a container client
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

        //Create a unique name for the container
        string containerName = "quickstartblobs" + Guid.NewGuid().ToString();

        // Create the container and return a container client object
        BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);*/
    }
}