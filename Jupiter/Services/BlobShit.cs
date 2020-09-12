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

namespace Jupiter.Services
{
    public class BlobShit

    {
        #region Variables
        private readonly string BlobPattern = "Blob";
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
        public  async Task<BlobContainerClient> CreateUserContainer(string userEmail)
        {
            #region variables
            string newContainer = BlobPattern + userEmail;
            string modified =newContainer.ToLower();
            #endregion
            #region TryCatch
            try
            {
                // Create the container
                Console.WriteLine(BlobSClient.AccountName.ToString());
                Console.WriteLine("hi");
                Console.WriteLine(modified.ToString());
                 await BlobSClient.CreateBlobContainerAsync(modified);

                /*       if (await container.ExistsAsync())
                       {
                           Console.WriteLine("Created container {0}", container.Name);
                           return container;
                       }*/
                
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine("HTTP error code {0}: {1}",
                                    e.Status, e.ErrorCode);
                Console.WriteLine(e.Message);
            }

            return null;
            #endregion
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