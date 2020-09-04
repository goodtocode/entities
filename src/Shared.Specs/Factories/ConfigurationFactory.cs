using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Shared.Specs
{
    public class ConfigurationFactory
    {
        public struct Environments
        {
            public static string Development = "Development";
            public static string Staging = "Staging";
            public static string Production = "Production";
        }

        private string _environment = string.Empty;

        public IConfiguration Configuration { get; }
        public string ConfigDirectory { get; set; }
        public string CurrentEnvironment { 
            get { if (_environment.IsNullOrWhiteSpace()) _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development"; 
                return _environment; } 
            set { _environment = value; } }
        public string BaseConfigFile { get; set; } = "appsettings.json";
        public string EnvironmentConfigFile { get { return $"appsettings.{CurrentEnvironment}.json"; } }

        public ConfigurationFactory(string configDirectory)
        {

            ConfigDirectory = FindConfiguration(configDirectory);
        }

        public string FindConfiguration(string configDirectory)
        {
            var returnValue = configDirectory;
            if (Directory.GetFiles(configDirectory, BaseConfigFile).Length == 0)
            {
                if (Directory.GetFiles(Directory.GetCurrentDirectory(), BaseConfigFile).Length > 0)
                    returnValue = Directory.GetCurrentDirectory();
                else if (Directory.GetParent(Directory.GetCurrentDirectory()).GetFiles(BaseConfigFile).Length > 0)
                    returnValue = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            }

            return returnValue;
        }

        public IConfiguration Create()
        {
            return new ConfigurationBuilder().SetBasePath(ConfigDirectory)
              .AddJsonFile(EnvironmentConfigFile)
              .AddJsonFile(BaseConfigFile)
              .Build();
        }
    }
}
