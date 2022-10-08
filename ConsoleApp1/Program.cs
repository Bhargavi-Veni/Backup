using Azure.Identity;
using Microsoft.Graph.Beta;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var scopes = new[] { "eDiscovery.Read.All", "eDiscovery.ReadWrite.All" };

            // Multi-tenant apps can use "common",
            // single-tenant apps must use the tenant ID from the Azure portal
            var tenantId = "6263835f-400b-4736-8b64-52412bc8a726";

            // Values from app registration
            var clientId = "85a9a4b9-9961-4ff0-b90a-de34c840682b";
            var clientSecret = "vqA7Q~KxPiaC9XCQu1hpnCDxnNPW4NBY9L7KZ";

            // For authorization code flow, the user signs into the Microsoft
            // identity platform, and the browser is redirected back to your app
            // with an authorization code in the query parameters
            var authorizationCode = "AUTH_CODE_FROM_REDIRECT";

            // using Azure.Identity;
            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            // https://docs.microsoft.com/dotnet/api/azure.identity.authorizationcodecredential
            var authCodeCredential = new AuthorizationCodeCredential(
                tenantId, clientId, clientSecret, authorizationCode, options);

            var graphClient = new GraphServiceClient(authCodeCredential, scopes);

            

            // Multi-tenant apps can use "common",
            // single-tenant apps must use the tenant ID from the Azure portal
            

            // Values from app registration
            
            //var clientCertificate = new X509Certificate2("MyCertificate.pfx");

            //// using Azure.Identity;
            //var options = new TokenCredentialOptions
            //{
            //    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            //};

            //// https://docs.microsoft.com/dotnet/api/azure.identity.clientcertificatecredential
            //var clientCertCredential = new ClientCertificateCredential(
            //    tenantId, clientId, clientCertificate, options);

            //var graphClient = new GraphServiceClient(clientCertCredential, scopes);
            var cases = graphClient.Compliance.Ediscovery.Cases
    .CreateGetRequestInformation();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
