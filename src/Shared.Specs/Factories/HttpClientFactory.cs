using GoodToCode.Shared.Extensions;
using System.Net.Http;

namespace GoodToCode.Shared.Specs
{
    public class HttpClientFactory
    {
        public HttpClientFactory()
        {            
        }

        public HttpClient CreateJsonClient<T>() where T : class, new()
        {            
            return new HttpClientJson<T>();
        }
    }
}
