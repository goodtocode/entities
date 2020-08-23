using System.Net.Http;

namespace GoodToCode.Shared.Specs
{
    public class HttpClientFactory
    {
        public HttpClient Client { get; }

        public HttpClientFactory()
        {
            Client = new HttpClient();
        }

        public HttpClient Create()
        {
            return Client;
        }
    }
}
