using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Hosting;
using System;

namespace GoodToCode.Locality.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // dotnet user-secrets init; dotnet user-secrets set ConnectionStrings:AppConfig "<your_connection_string>"
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        var settings = config.Build();
                        var connection = settings.GetConnectionString("AppConfig") ?? Environment.GetEnvironmentVariable("AppSettingsConnection");
                        config.AddAzureAppConfiguration(options =>
                            options
                                .Connect(connection)
                                // Load configuration values with no label
                                .Select(KeyFilter.Any, LabelFilter.Null)
                                // Override with any configuration values specific to current hosting env
                                .Select(KeyFilter.Any, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production")
                        );
                    }).UseStartup<Startup>());
    }
}
