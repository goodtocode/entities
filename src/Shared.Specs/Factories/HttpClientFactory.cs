using System.Net.Http;
using System.Net.Http.Headers;

namespace GoodToCode.Shared.Specs
{
    public class HttpClientFactory
    {
        public HttpClient Client { get; }

        public HttpClientFactory()
        {
            Client = new HttpClient();
        }

        public HttpClient CreateJsonClient()
        {
            Client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Client;
        }
    }
}
