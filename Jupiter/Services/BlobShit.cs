using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using System.Threading;
using Azure;
using System.Security.Cryptography.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace Jupiter.Services
{
    public class BlobShit

    {
        #region Variables
        private readonly string BlobPattern = "blob";
        private readonly string ContainerPattern = "container";
        #endregion
        #region Properties
        public BlobServiceClient BlobSClient { get; set; }
        /*public BlobContainerClient BlobCClient { get; set; }*/
        #endregion
        #region Constructor
         public BlobShit()
        {
            try {
                BlobSClient = new BlobServiceClient(ConfigurationManager.AppSettings.Get("ConnectionStrings--JupiterJazzStorageKey"));
               
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }
        #endregion
        #region Functions

        public (bool SuccessStatus,string ContainerName,string ContainerURI) CreateUserContainer(string userEmail)
        {
            #region variables
          /*  Regex rgx = new Regex("[^a-zA-Z0-9 -]");*/
            
            string randomNumber = Guid.NewGuid().ToString();
            string _ = ContainerPattern + userEmail+randomNumber;
            string temp_toLower =_.ToLower();
            /*string submittedContainerName = rgx.Replace(temp_toLower, "");*/

            string containerName = string.Empty;
            string uri = string.Empty;
            bool SuccessStatus = false;

            IDictionary<string, string> ContainerTags = new Dictionary<string, string>();
            ContainerTags.Add("Owner", userEmail);

            #endregion
            #region TryCatch
            try
            {
                // Create the container

                BlobContainerClient container = BlobSClient.CreateBlobContainer(temp_toLower, PublicAccessType.Blob,ContainerTags);
                containerName = container.Name;
                uri = container.Uri.ToString();
                SuccessStatus = true;
                
 
            }
            catch (Azure.RequestFailedException RF)
            {
                
                Console.WriteLine(RF.Message);
                Console.WriteLine("Failure from CreateuserContainer");
            }

            return (SuccessStatus, containerName, uri); 
            #endregion
        }
        
        public int ListUserBlobsInContainer(string userEmail)
        {
            #region Variables
            List<string> blobList = new List<string>();
            int count = 100;
            #endregion
            #region TryExecute
            try
            {
                Pageable<BlobContainerItem> blobContainers = BlobSClient.GetBlobContainers();
                count = blobContainers.Count();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            #endregion
            return count;
        }
        public bool DeleteUserContainer(string userEmail)
        { 
            throw new NotImplementedException();

        }
        public string InsertIntoUserContainer(string userContainerName,string filename,Stream filestream)
        {
            #region Variables
            string UploadStatus = string.Empty;
            #endregion
            #region TryExecuteUploadBlob
            try
            {
                BlobContainerClient BlobCClient = new BlobContainerClient(ConfigurationManager.AppSettings.Get("ConnectionStrings--JupiterJazzStorageKey"), userContainerName);
             BlobContentInfo response=   BlobCClient.UploadBlob(filename, filestream);

                /*    if (response.LastModified.Date != null)
                    { 
                    UploadStatus = true;

                    }*/
                UploadStatus = "ok";
            }
            catch (Azure.RequestFailedException RFE)
            {
                UploadStatus = RFE.ErrorCode+" "+RFE.Status.ToString();
                Console.WriteLine(RFE.Message);
            }
            #endregion
            return UploadStatus;
        }
      
        #endregion
    }
}