using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
namespace TestKeyVault
{
    class Shit
    {
        public Shit()
        {
             KeyVaultTest();
        }
        /// <summary>
        /// Gets the access token
        /// The parameters will be provided automatically, you don't need to understand them
        /// </summary>
        /// <param name="authority"> Authority </param>
        /// <param name="resource"> Resource </param>
        /// <param name="scope"> scope </param>
        /// <returns> token </returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            ClientCredential clientCredential = new ClientCredential(clientId, clientSecret);

            AuthenticationContext context = new AuthenticationContext(authority, TokenCache.DefaultShared);

            AuthenticationResult result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
            return result.AccessToken;
        }
        public async Task<string> KeyVaultTest()
        {
            string vaultBaseUrl = "https://JupiterJazzKeyVault1.vault.azure.net";
            string secretName = "JupiterJazzKeyValutSecretKeyJupiterJazzStorageConnectionString";

            // Connect client
            KeyVaultClient keyclient;
            try
            {
                keyclient = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(GetAccessToken)
                );
                Console.WriteLine("hi from keyclient try");
            }
            catch (Exception keyVaultClientException )
            {
                throw new Exception("client construction: " + keyVaultClientException.Message);
                Console.WriteLine(keyVaultClientException.Message);
                Console.WriteLine("hi from keyclient exception");
               

            }

            // Set secret
            string secret = "My s3cr3t value!";
            try
            {
                SecretBundle result = await keyclient.SetSecretAsync(vaultBaseUrl, secretName, secret);
                Console.WriteLine(result.Value.Length);
                Console.WriteLine("hi from set secrete try");

            }
            catch (Exception setSecretException)
            {
                throw new Exception("set secret: " + setSecretException.Message);
                Console.WriteLine("hi from set secrete try exception");

            }
            // Read secret
            try
            {
                string secretUrl = $"{vaultBaseUrl}/secrets/{secretName}";
                SecretBundle secretWeJustWroteTo = await keyclient.GetSecretAsync(secretUrl);
                return secretWeJustWroteTo.Value;
                Console.WriteLine("hi from try read secret ");

            }
            catch (Exception getSecretException)
            {
                throw new Exception("get secret: " + getSecretException.Message);
                Console.WriteLine("hi from try read secret catchS ");

            }

        }
    }
}
