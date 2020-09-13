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
        public bool UserContainerExist(string userEmail)
        {
            throw new NotImplementedException();
        }
        /*    public string CreateUserContainer(string userEmail)
            {
                #region Variables
                    IDictionary<string, string> metadata = new Dictionary<string, string>();
                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;
                string responseString = string.Empty;

                #endregion
                #region TryCatchExecute
                try
                {
                   var response= BlobClient.CreateBlobContainer(BlobPattern + userEmail, PublicAccessType.Blob,metadata, token);
                    responseString=response.GetRawResponse().ToString();
                }
                catch(Exception e)
                { Console.WriteLine(e.Message); }

                #endregion
                return responseString;
            }*/
        /*   public bool CreateUserContainer(string userEmail)
           {
               #region variables
               string newContainer =  BlobPattern + userEmail;
               newContainer.ToLower();
               #endregion
               #region HttpRequest
               HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ldbstorage.blob.core.windows.net/"+ newContainer+"? restype=container");
               #endregion
               throw new NotImplementedException();
           }*/
        public (bool SuccessStatus,string ContainerName,string ContainerURI) CreateUserContainer(string userEmail)
        {
            #region variables
            string randomNumber = Guid.NewGuid().ToString();
            string _ = ContainerPattern + userEmail+randomNumber;
            string newContainer =_.ToLower();

            string containerName = string.Empty;
            string uri = string.Empty;
            bool SuccessStatus = false;

            IDictionary<string, string> ContainerTags = new Dictionary<string, string>();
            ContainerTags.Add("Owner", userEmail);

            #endregion
            #region TryCatchContainerExist
            
            #endregion
            #region TryCatch
            try
            {
                // Create the container

                BlobContainerClient container = BlobSClient.CreateBlobContainer(newContainer,PublicAccessType.Blob,ContainerTags);
                containerName = container.Name;
                uri = container.Uri.ToString();
                SuccessStatus = true;
                
 
            }
            catch (Azure.RequestFailedException RF)
            {
                
                Console.WriteLine(RF.Message);
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
        public bool InsertIntoUserContainer(string userEmail)
        { 
            throw new NotImplementedException();

        }
        #endregion
    }
}