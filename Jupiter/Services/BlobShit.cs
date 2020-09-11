using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Configuration;
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
        public BlobServiceClient BlobClient { get; set; } 
        #endregion
        #region Constructor
         public BlobShit()
        {
            try {
                BlobClient = new BlobServiceClient(ConfigurationManager.AppSettings.Get("ConnectionStrings--JupiterJazzStorageKey"));
                
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
        public string CreateUserContainer(string userEmail)
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