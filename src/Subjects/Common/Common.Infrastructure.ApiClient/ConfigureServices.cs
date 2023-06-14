using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System.Xml.Linq;

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

            // Example
            //var myOptions = new MyOptions();
            //Configuration.GetSection("MyOptions").Bind(myOptions);
            //services.AddSingleton(myOptions);

            //services.AddSingleton<IMyService>(provider =>
            //{
            //    var options = provider.GetRequiredService<MyOptions>();
            //    return new MyService(options);
            //});

            return services;
        }
    }
}
