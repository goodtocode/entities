using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GoodToCode.Shared.Extensions
{
    public class HttpClientJson<T> : HttpClient where T : class, new()
    {
        public HttpClientJson() : base()
        {
            DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<HttpResponseMessage> PutAsync(Uri url, T item)
        {
            return PutAsync(url, new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
        }

        public Task<HttpResponseMessage> PostAsync(Uri url, T item)
        {
            return PostAsync(url, new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
        }
    }
}
