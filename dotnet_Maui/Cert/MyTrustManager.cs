using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace dotnet_Maui.Cert
{
    public static class CertificateValidation
    {
        public static HttpClientHandler GetHttpClientHandler()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    // Ignore SSL certificate errors
                    return true;
                }
            };
            return handler;
        }
    }
}

