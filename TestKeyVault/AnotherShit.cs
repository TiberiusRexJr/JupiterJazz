using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
namespace TestKeyVault
{
    class AnotherShit
    {
        public AnotherShit()
        { 
        }

        public void SecretClient()
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
            };
            var client = new SecretClient(new Uri("https://JupiterJazzKeyVault1.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret("mySecret");

            string secretValue = secret.Value;
        }
     
    }
}
