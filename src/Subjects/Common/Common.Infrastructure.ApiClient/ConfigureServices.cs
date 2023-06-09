using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Goodtocode.Common.Infrastructure.ApiClient
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiClientServices(this IServiceCollection services,
            string apiClientName, string url, ClientCredentialSetting configureClient)
        {            
            services.AddTransient<BearerTokenHandler>();
            services.AddSingleton<AccessToken>(new AccessToken(configureClient));
            services.AddHttpClient(apiClientName, client =>
                    {
                        client.DefaultRequestHeaders.Clear();
                        client.BaseAddress = new Uri(url);
                    }
                ).AddHttpMessageHandler<BearerTokenHandler>()
                .AddPolicyHandler(
                    Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                        .RetryAsync(3)
                );

            return services;
        }
    }
}
