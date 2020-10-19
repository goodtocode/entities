using GoodToCode.Shared.Specs.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GoodToCode.Shared.Specs
{
    public struct ConfigurationEnvironments
    {
        public static string Local = "Local";
        public static string Development = "Development";
        public static string Staging = "Staging";
        public static string Production = "Production";
    }

    public class ConfigurationFactory
    {
        public string CurrentEnvironment { get { return new EnvironmentVariableFactory().CreateASPNETCORE_ENVIRONMENT(); } }
        public IConfiguration Configuration { get; }
        public string JsonPathOrAzureConnection { get; set; }
        public string BaseConfigFile { get { return "appsettings.json"; } }
        public string EnvironmentConfigFile { get { return $"appsettings.{CurrentEnvironment}.json"; } }
        public List<string> ConfigFiles { get; set; } = new List<string>();

        public string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public ConfigurationFactory()
        {
            JsonPathOrAzureConnection = Environment.GetEnvironmentVariable("AppSettingsConnection");
        }

        public ConfigurationFactory(string jsonPathOrAzureConnection) : this()
        {
            JsonPathOrAzureConnection = jsonPathOrAzureConnection;
        }

        public ConfigurationFactory(string defaultPath, List<string> configFiles) : this(defaultPath)
        {
            ConfigFiles = configFiles;
        }

        public IConfiguration CreateFromAzureSettings(string sentinelAppSetting = "Stack:Shared:Sentinel")
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(options =>
                    options
                        .Connect(JsonPathOrAzureConnection ?? Environment.GetEnvironmentVariable("AppSettingsConnection"))
                        .ConfigureRefresh(refresh =>
                        {
                            refresh.Register(sentinelAppSetting, refreshAll: true)
                                    .SetCacheExpiration(new TimeSpan(0, 60, 0));
                        })
                        .Select(KeyFilter.Any, LabelFilter.Null)
                        .Select(KeyFilter.Any, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production")
                    );
            return builder.Build();
        }

        public IConfiguration CreateFromJsonSettings()
        {
            JsonPathOrAzureConnection = FindConfiguration(JsonPathOrAzureConnection);
            if (!ConfigFiles.Any()) ConfigFiles.AddRange(new string[] { BaseConfigFile, EnvironmentConfigFile });
            var returnValue = new ConfigurationBuilder().SetBasePath(JsonPathOrAzureConnection);
            foreach (var item in ConfigFiles)
            {
                returnValue.AddJsonFile(item);
            }

            return returnValue.Build();
        }

        private string FindConfiguration(string configDirectory)
        {
            var returnValue = string.Empty;

            if (SearchDirectoryAndParent(configDirectory).Length > 0)
                returnValue = configDirectory;
            else if (SearchDirectoryAndParent(AssemblyDirectory).Length > 0)
                returnValue = SearchDirectoryAndParent(AssemblyDirectory);
            else if (SearchDirectoryAndParent(Directory.GetCurrentDirectory()).Length > 0)
                returnValue = SearchDirectoryAndParent(Directory.GetCurrentDirectory());

            return returnValue;
        }

        private string SearchDirectoryAndParent(string configDirectory)
        {
            var returnValue = string.Empty;
            if (Directory.GetFiles(configDirectory, BaseConfigFile).Length > 0)
                returnValue = configDirectory;
            else if (Directory.GetParent(configDirectory).GetFiles(BaseConfigFile).Length > 0)
                returnValue = Directory.GetParent(configDirectory).FullName;

            return returnValue;
        }
    }
}
