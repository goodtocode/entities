using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System;

namespace GoodToCode.Shared.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfiguration AddAzureAppConfigurationDefault(this ConfigurationBuilder item)
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(options =>
                            options
                                .Connect(Environment.GetEnvironmentVariable("AppSettingsConnection"))
                                .ConfigureRefresh(refresh =>
                                {
                                    refresh.Register("Stack:Shared:RefreshSentinel", refreshAll: true)
                                           .SetCacheExpiration(new TimeSpan(0, 60, 0));
                                })
                                .Select(KeyFilter.Any, LabelFilter.Null)
                                .Select(KeyFilter.Any, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production")
                        );
            return builder.Build();
        }
    }
}
