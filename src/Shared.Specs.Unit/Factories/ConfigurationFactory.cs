using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
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
        public string CurrentEnvironment
        {
            get
            {
                if (_environment.IsNullOrWhiteSpace()) _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development";
                return _environment;
            }
            set { _environment = value; }
        }
        public string BaseConfigFile { get; set; } = "appsettings.json";
        public string EnvironmentConfigFile { get { return $"appsettings.{CurrentEnvironment}.json"; } }
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
            ConfigDirectory = FindConfiguration(AssemblyDirectory);
        }

        public ConfigurationFactory(string configDirectory)
        {
            ConfigDirectory = FindConfiguration(configDirectory);
        }

        public string FindConfiguration(string configDirectory)
        {
            var returnValue = configDirectory;
            if (SearchDirectoryAndParent(configDirectory).Length > 0)
                returnValue = configDirectory;
            else if (SearchDirectoryAndParent(AssemblyDirectory).Length > 0)
                returnValue = SearchDirectoryAndParent(AssemblyDirectory);
            else if (SearchDirectoryAndParent(Directory.GetCurrentDirectory()).Length > 0)
                returnValue = SearchDirectoryAndParent(Directory.GetCurrentDirectory());

            return returnValue;
        }

        public string SearchDirectoryAndParent(string configDirectory)
        {
            var returnValue = string.Empty;
            if (Directory.GetFiles(configDirectory, BaseConfigFile).Length > 0)
                returnValue = configDirectory;
            else if (Directory.GetParent(configDirectory).GetFiles(BaseConfigFile).Length > 0)
                returnValue = Directory.GetParent(configDirectory).FullName;

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
